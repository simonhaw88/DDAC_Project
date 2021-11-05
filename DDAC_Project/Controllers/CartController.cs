using DDAC_Project.Helper;
using DDAC_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DDAC_Project.Controllers
{
    public class CartController : Controller
    {
        ApiHelper _api = new ApiHelper();
        private HttpClient client;
        private readonly string seassion_userId = "userId";
        private readonly string seassion_role = "role";
        public CartController()
        {
            client = _api.Initial();
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);

            if (!userId.HasValue || role != (int)UserEnum.Customer)
            {
                return RedirectToAction("Login", "Auth");
            }
            //get customer id
            Customer customer = new Customer();
            HttpResponseMessage responseGetCustomer = await this.client.GetAsync($"api/customer?userId={userId}");
            if (responseGetCustomer.IsSuccessStatusCode)
            {
                var result = responseGetCustomer.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(result);
            }

            int customerId = 1;
            customerId = customer.CustomerId;
            //get all cart item of customer
            List<CartItem> cartItems = new List<CartItem>();
            HttpResponseMessage responseGetCartItems = await this.client.GetAsync($"api/cart/customerId={customerId}");
            if (responseGetCartItems.IsSuccessStatusCode)
            {
                var result = responseGetCartItems.Content.ReadAsStringAsync().Result;
                cartItems = JsonConvert.DeserializeObject<List<CartItem>>(result);
            }

            //pre select item in cart to be paid
            var cartItemId = HttpContext.Session.GetInt32("cartItemId");

            if (cartItemId.HasValue)
            {
                cartItems.Where(a => a.CartItemId == cartItemId).FirstOrDefault().IsSelected = true;
                HttpContext.Session.Remove("cartItemId");
            }
            var message = TempData["fail"];
            if (message != null)
            {
                ModelState.AddModelError("fail", message.ToString());

            }
            ViewBag.Url = "Cart";

            return View(cartItems);
        }

        public async Task<IActionResult> Remove(int id = 0)
        {
            string status = null;
            string message = null;

            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);

            if (!userId.HasValue || role != (int)UserEnum.Customer)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (id != 0)
            {
                //get cart item
                CartItem cartItem = new CartItem();
                HttpResponseMessage responseGetCartItem = await this.client.GetAsync($"api/cart/id={id}");
                if (responseGetCartItem.IsSuccessStatusCode)
                {
                    var result = responseGetCartItem.Content.ReadAsStringAsync().Result;
                    cartItem = JsonConvert.DeserializeObject<CartItem>(result);
                }

                //get album 
                Album album = new Album();
                HttpResponseMessage responseGetAlbum = await this.client.GetAsync($"api/album/{cartItem.AlbumId}");
                if (responseGetAlbum.IsSuccessStatusCode)
                {
                    var result = responseGetAlbum.Content.ReadAsStringAsync().Result;
                    album = JsonConvert.DeserializeObject<Album>(result);
                }
                //update album's quantity
                album.Stock = album.Stock + cartItem.Quantity;
                HttpResponseMessage responseUpdateAlbum = await client.PutAsJsonAsync("api/album/updateAlbum", album);

                //delete cart item
                HttpResponseMessage responseDelete = await this.client.DeleteAsync(
                                                   $"api/cartItem/delete/{id}");

                if (responseDelete.IsSuccessStatusCode)
                {
                    status = "success";
                    message = "Cart item removed successfully";

                }
                else
                {
                    status = "fail";
                    message = responseDelete.Content.ReadAsStringAsync().Result;
                }

            } else
            {
                status = "fail";
                message = "Cart item id cannot be null";
            }
            return Json(new { status = status, message = message });

        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int albumId, int quantity)
        {
            string status = null;
            string message = null;

            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);

            if (!userId.HasValue || role != (int)UserEnum.Customer )
            {
                status = "user_invalid";
                message = "Login first before making any purchase.";
             }

            //get customer id
            Customer customer = new Customer();
            HttpResponseMessage responseGetCustomer = await this.client.GetAsync($"api/customer?userId={userId}");
            if (responseGetCustomer.IsSuccessStatusCode)
            {
                var result = responseGetCustomer.Content.ReadAsStringAsync().Result;
                customer = JsonConvert.DeserializeObject<Customer>(result);
            }

            //get album
            Album album = new Album();
            HttpResponseMessage responseGetAlbum = await this.client.GetAsync($"api/album/{albumId}");
            if (responseGetAlbum.IsSuccessStatusCode)
            {
                var result = responseGetAlbum.Content.ReadAsStringAsync().Result;
                album = JsonConvert.DeserializeObject<Album>(result);
            }
             int customerId = 0;
            //put album into cart
             if (customer != null && album != null)
             {
                if ((album.Stock - quantity) < 0)
                {
                    status = "fail";
                    message = "Not enough stock";
                }
                else
                {
                    //update album's quantity
                    album.Stock = album.Stock - quantity;
                    HttpResponseMessage responseUpdateAlbum = await client.PutAsJsonAsync("api/album/updateAlbum", album);
                  
                    //add to cart
                    customerId = customer.CustomerId;
                    CartItem cartItem = new CartItem() { Quantity = quantity, Price = album.Price, AlbumId = album.AlbumId, CustomerId = customerId };
                    HttpResponseMessage responsePostCartItem = await this.client.PostAsJsonAsync(
                                        "api/cart/postCartItem", cartItem);
                    if (responsePostCartItem.IsSuccessStatusCode)
                    {
                        var result = responsePostCartItem.Content.ReadAsStringAsync().Result;
                        cartItem = JsonConvert.DeserializeObject<CartItem>(result);
                        status = "success";
                        message = "Add to cart successfully";
                        HttpContext.Session.SetInt32("cartItemId", cartItem.CartItemId);
                    }
                }
             } else
            {
                status = "fail";
                message = "System error.";
            }
            
            return Json(new { status = status, message = message });

        }
    }
}
