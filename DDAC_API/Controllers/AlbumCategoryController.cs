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
    public class AlbumCategoryController : Controller
    {
        private readonly DDAC_Context _context;

        public AlbumCategoryController(DDAC_Context context)
        {   
            _context = context;
        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AlbumCategory>>> GetCategories()
        {
            return await _context.AlbumCategorys.ToListAsync();
        }

    }
}
