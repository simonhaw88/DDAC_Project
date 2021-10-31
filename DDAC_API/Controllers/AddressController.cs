using DDAC_API.Data;
using DDAC_API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace DDAC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AddressController : ControllerBase
    {
        private readonly DDAC_Context _context;

        public AddressController(DDAC_Context context)
        {
            _context = context;
        }

        [HttpGet("{id}")]
        public ActionResult<Address> GetAddress(int id)
        {
            Address address = _context.Address.FirstOrDefault(u => u.AddressId == id);

            if (address == null)
            {
                return NotFound();
            }
            return address;
        }

        [HttpPost]
        public async Task<ActionResult<Address>> PostAddress(Address address)
        {
            _context.Address.Add(address);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetAddress", new { id = address.AddressId }, address);
        }
    }
}
