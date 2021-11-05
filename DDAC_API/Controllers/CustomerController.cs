using DDAC_API.Data;
using DDAC_API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : Controller
    {
        private readonly DDAC_Context _context;

        public CustomerController(DDAC_Context context)
        {
            _context = context;
        }

        //api/customer?userId=2
        [HttpGet]
        public ActionResult<Customer> GetCustomer(int userId)
        {
            Customer customer = _context.Customers.Include(a=>a.User).Include(a=>a.Address).FirstOrDefault(u => u.UserId == userId);

            if (customer == null)
            {
                return NotFound();
            }
            return customer;
        }
    }
}
