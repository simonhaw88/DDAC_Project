using DDAC_API.Data;
using DDAC_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffController : Controller
    {
        private readonly DDAC_Context _context;

        public StaffController(DDAC_Context context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Staff>>> GetStaffs()
        {
            return await _context.Staffs
                .Include(a => a.User)
                .Include(a=>a.Address)
                .OrderByDescending(e => e.StaffId)
                .Where(a=>a.User.Role == 2)
                .ToListAsync();
        }

        [HttpGet("{id}")]
        public ActionResult<Staff> GetStaff(int id)
        {
            Staff staff = _context.Staffs.FirstOrDefault(u => u.StaffId== id);

            if (staff == null)
            {
                return NotFound();
            }
            return staff;
        }

        [HttpPost]
        public async Task<ActionResult<Staff>> PostStaff(Staff staff)
        {
            _context.Staffs.Add(staff);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetStaff", new { id = staff.StaffId }, staff);
        }
    }

}
