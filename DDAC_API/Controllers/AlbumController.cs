using DDAC_API.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDAC_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DDAC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AlbumController : ControllerBase
    {
        private readonly DDAC_Context _context;

        public AlbumController(DDAC_Context context)
        {
            _context = context;
        }



        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _context.Albums
                .Include(a => a.Tracks)
                .Include(a=>a.AlbumCategory)
                .Include(a=>a.AlbumPhotos)
                .OrderByDescending(e=>e.AlbumId)
                .ToListAsync();
        }

       
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<Album>>> SearchAlbums(string type, string value)
        {
             
            IQueryable<Album> albums = _context.Albums;
            if (type != null && value !=null )
            {
                if(type == "name")
                {
                    albums = albums.Where(a => a.Name.Contains(value));
                } else if(type == "category")
                {
                    albums = albums.Where(a => a.AlbumCategoryId == Convert.ToInt32(value));
                }

            }
            
            var result = await albums.
                Include(a => a.Tracks).
                Include(a => a.AlbumCategory).
                Include(a => a.AlbumPhotos).
                OrderByDescending(e => e.AlbumId).
                ToListAsync();

            if (result == null)
            {
                return NotFound();
            }

            return result;
           
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _context.Albums.Include(a => a.Tracks).Include(a => a.AlbumCategory).Include(a => a.AlbumPhotos).FirstOrDefaultAsync(a => a.AlbumId == id);

            if (album == null)
            {
                return NotFound();
            }

            return album;
        }

        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteAlbum(int id)
        {
            var album = await _context.Albums.FindAsync(id);
            if (album == null)
            {
                return NotFound();
            }

            _context.Albums.Remove(album);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpPut("updateAlbum")]
        public async Task<ActionResult> PutAlbum(Album album)
        {
            
            _context.Entry(album).State = EntityState.Modified;

             await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost("postAlbum")]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAlbum", new { id = album.AlbumId}, album);
        }

       

    }
}
