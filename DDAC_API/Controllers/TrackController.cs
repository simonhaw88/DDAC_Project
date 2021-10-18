using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDAC_API.Models;
using DDAC_API.Data;
using Microsoft.EntityFrameworkCore;

namespace DDAC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrackController : Controller
    {
        private readonly DDAC_Context _context;

        public TrackController(DDAC_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<Track>> GetTrack(int id)
        {
            var track = await _context.Tracks.FirstOrDefaultAsync(a => a.TrackId == id);

            if (track == null)
            {
                return NotFound();
            }

            return track;
        }


        [HttpPost]
        public async Task<ActionResult<Track>> PostTrack(Track track)
        {
            _context.Tracks.Add(track);
            await _context.SaveChangesAsync();
            return CreatedAtAction("GetTrack", new { id = track.TrackId}, track);
        }
        

    }
}
