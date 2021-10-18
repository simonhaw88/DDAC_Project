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
    public class AlbumPhotoController : Controller
    {
        private readonly DDAC_Context _context;

        public AlbumPhotoController(DDAC_Context context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<AlbumPhoto>> GetAlbumPhoto(int id)
        {
            var albumPhoto = await _context.AlbumPhotos.FirstOrDefaultAsync(a => a.AlbumPhotoId == id);

            if (albumPhoto == null)
            {
                return NotFound();
            }

            return albumPhoto;
        }

        [HttpPost("{albumPhoto}")]
        public async Task<ActionResult<AlbumPhoto>> PostAlbumPhoto(AlbumPhoto albumPhoto)
        {
            _context.AlbumPhotos.Add(albumPhoto);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAlbum", new { id = albumPhoto }, albumPhoto);

        }
    }
}
