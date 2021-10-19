using Microsoft.AspNetCore.Mvc;
using System;
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

        [HttpGet("email={email}")]
        public  ActionResult<bool> EmailIsExist(string email)
        {
            User user = _context.Users.FirstOrDefault(u => u.Email == email);
          
            if(user == null)
            {
                return false;
            }
            return true;
        }

        [HttpPost]
        public async Task<ActionResult<User>> PostUser(User usr)
        {
            _context.Users.Add(usr);
            await _context.SaveChangesAsync();

            return Ok();
        }

        [HttpPost("verifyUser")]
        public ActionResult<User> VerifyUser(User usr)
        {
            return _context.Users.Where(d => d.Email == usr.Email && d.Password == usr.Password && d.Role == usr.Role).FirstOrDefault();
            
 
        }
    }
}
