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
    public class CartController : Controller
    {
        private readonly DDAC_Context _context;

        public CartController(DDAC_Context context)
        {
            _context = context;
        }

     
        [HttpGet("id={id}")]
        public ActionResult<CartItem> GetCartItem(int id)
        {
            CartItem cartItem = _context.CartItems
                .Include(a => a.Customer)
                .Include(a => a.Album)
                .ThenInclude(a => a.AlbumPhotos)
                .FirstOrDefault(u => u.CartItemId == id);

            if (cartItem == null)
            {
                return NotFound();
            }
            return cartItem;
        }

        [HttpGet("customerId={customerId}")]
        public async Task<ActionResult<IEnumerable<CartItem>>> GetCartItemByCustomerId(int customerId)
        {
            List<CartItem> cartItems = await _context.CartItems
                .Where(u => u.CustomerId == customerId)
                .Include(a=>a.Customer)
                .Include(a=>a.Album)
                .ThenInclude(a=>a.AlbumPhotos)
                .ToListAsync();

            if (cartItems == null)
            {
                return NotFound();
            }
            return cartItems;
        }

        [HttpPost("postCartItem")]
        public async Task<ActionResult<CartItem>> PostCartItem(CartItem cartItem)
        {
            _context.CartItems.Add(cartItem);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCartItem", new { id = cartItem.CartItemId }, cartItem);
        }

    }
}
