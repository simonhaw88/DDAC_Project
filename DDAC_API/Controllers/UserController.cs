using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDAC_API.Data;
using DDAC_API.Models;
using Microsoft.EntityFrameworkCore;

namespace DDAC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly DDAC_Context _context;

        public UserController(DDAC_Context context)
        {
            _context = context;
        }

        [HttpGet("count_user")]
        public ActionResult<int> CountUser(string email, int role = 0)
        {
            IQueryable<User> users = _context.Users;
            if (role != 0)
            {
                users = users.Where(a => a.Role == role);
                if (role == (int)UserEnum.Admin)
                {
                    users = users.Include(a => a.Admin.Address);
                }
                else if (role == (int)UserEnum.Customer)
                {
                    users = users.Include(a => a.Customer.Address);
                }
                else if (role == (int)UserEnum.Staff)
                {
                    users = users.Include(a => a.Staff.Address);
                }

            }
            if (email != null)
            {
                users = users.Where(a => a.Email.Contains(email));

            }

            var result = users.OrderByDescending(e => e.UserId).Count();
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }

        //api/user/search
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<User>>> SearchUsers(string email, int role = 0, int pageNumber = 1, int pageSize = 15)
        {
            int excludeRecords = (pageSize * pageNumber) - pageSize;

            IQueryable<User> users = _context.Users;
            if (role != 0)
            {
                users = users.Where(a => a.Role == role);
                if(role == (int)UserEnum.Admin)
                {
                    users = users.Include(a => a.Admin.Address);
                }
                else if(role == (int)UserEnum.Customer)
                {
                    users = users.Include(a => a.Customer.Address);
                }
                else if(role == (int)UserEnum.Staff)
                {
                    users = users.Include(a => a.Staff.Address);
                }

            }
            if(email != null)
            {
                users = users.Where(a => a.Email.Contains(email));

            }

            var result = await users.OrderByDescending(e => e.UserId).Skip(excludeRecords).
                Take(pageSize).ToListAsync();
            if (result == null)
            {
                return NotFound();
            }

            return result;
        }
        //api/user/delete/2
        [HttpDelete("delete/{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return Ok();
        }


        [HttpGet("email={email}")]
        public async Task<ActionResult<bool>> EmailIsExist(string email)
        {
            User user = await _context.Users.FirstOrDefaultAsync(u => u.Email == email);
          
            if(user == null)
            {
                return false;
            }
            return true;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            User user = await _context.Users
                .Include(e => e.Staff.Address)
                .Include(e=>e.Customer.Address)
                .Include(e=>e.Admin.Address)
                .FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [HttpPut("update")]
        public async Task<ActionResult> PutUser(User user)
        {

            _context.Update(user);

            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User usr)
        {
            _context.Users.Add(usr);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = usr.UserId }, usr);
        }

        [HttpPost("verifyUser")]
        public async Task<ActionResult<User>> VerifyUser(User usr)
        {
            return await _context.Users
                .Where(d => d.Email == usr.Email && d.Password == usr.Password && d.Role == usr.Role && d.Status == 1)
                .FirstOrDefaultAsync();
        }
    }
}
