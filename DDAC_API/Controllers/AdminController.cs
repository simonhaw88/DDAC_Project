using DDAC_API.Data;
using DDAC_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace DDAC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdminController : ControllerBase
    {
        private readonly DDAC_Context _context;

        public AdminController(DDAC_Context context)
        {
            _context = context;
        }

        [HttpPut("updateAdmin")]
        public async Task<ActionResult> PutAdmin(Admin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;

            await _context.SaveChangesAsync();

            return NoContent();
        }
        
        [HttpGet("{id}")]
        public async Task<ActionResult<Admin>> GetAdmin(int id)
        {
            var admin = await _context.Admins.Include(a => a.Address).Include(a=>a.User).FirstOrDefaultAsync(a => a.AdminId == id);

            if (admin == null)
            {
                return NotFound();
            }

            return admin;
        }
    }

}


