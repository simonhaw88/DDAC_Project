using DDAC_API.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDAC_API.Models;
using Microsoft.EntityFrameworkCore;
using cloudscribe.Pagination.Models;

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
            return await _context.Albums.Include(a => a.Tracks).Include(a => a.AlbumCategory).Include(a => a.AlbumPhotos).ToListAsync();
        }

       
        [HttpGet("category/{value}")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbumsByCategory( int value)
        {
            return await _context.Albums
                .Where(a=> a.AlbumCategoryId == value)
                .Include(a => a.Tracks)
                .Include(a => a.AlbumCategory)
                .Include(a => a.AlbumPhotos)
                .ToListAsync();

        }

        [HttpGet("name/{value}")]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbumsByName(string value)
        {
            return await _context.Albums
                .Where(a => a.Name.Contains(value))
                .Include(a => a.Tracks)
                .Include(a => a.AlbumCategory)
                .Include(a => a.AlbumPhotos)
                .ToListAsync();

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
        [HttpPost]
        public async Task<ActionResult<Album>> PostAlbum(Album album)
        {
            _context.Albums.Add(album);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetAlbum", new { id = album.AlbumId}, album);
        }

       
    }
}
