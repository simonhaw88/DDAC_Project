using DDAC_API.Data;
using Microsoft.AspNetCore.Http;
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

        // GET: api/Albums
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Album>>> GetAlbums()
        {
            return await _context.Albums.Include(a => a.Artist).ToListAsync();
        }

        [HttpGet]
        public async Task<ActionResult<Album>> GetAlbum(int id)
        {
            var album = await _context.Albums.Include(a => a.Artist).FirstOrDefaultAsync(a => a.AlbumId == id);

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

        [HttpPost("albumPhoto")]
        public async Task<ActionResult<AlbumPhoto>> PostAlbumPhoto(AlbumPhoto albumPhoto)
        {
            _context.AlbumPhotos.Add(albumPhoto);
            await _context.SaveChangesAsync();

            return Ok();
        }
    }
}
