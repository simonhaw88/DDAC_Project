using DDAC_Project.Data;
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
     public class AdminController : Controller
    {
        ApiHelper _api = new ApiHelper();
        private HttpClient client;
        private readonly string seassion_userId = "userId";
        private readonly string seassion_role = "role";

        public AdminController()
        { 
            client = _api.Initial();
        }

        [HttpGet]
        public async Task<IActionResult> Index(string date_filter = null )
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin)
            {
                return RedirectToAction("Login", "Auth");
            }

            if (date_filter == null)
            {
                date_filter = DateTime.Now.ToString("yyyy-MM-dd"); 
            }
            string date_now = DateTime.Now.ToString("yyyy-MM-dd");
            string time_from = DateTime.Now.AddMonths(-1).ToString("yyyy-MM-dd");            
            //get total sales
            Double total_sales = 0.0;
            HttpResponseMessage responseTotalSales = await this.client.GetAsync($"api/order/total_sales?timeFrom={date_filter}&timeTo={date_filter}&orderStatus=2");
            if (responseTotalSales.IsSuccessStatusCode)
            {
                var result = responseTotalSales.Content.ReadAsStringAsync().Result;
                total_sales = Convert.ToDouble(result);
            }
            //get total orders
            int total_order = 0;
            HttpResponseMessage responseTotalOrders = await this.client.GetAsync($"api/order/total_orders?timeFrom={date_filter}&timeTo={date_filter}&orderStatus=2");
            if (responseTotalOrders.IsSuccessStatusCode)
            {
                var result = responseTotalOrders.Content.ReadAsStringAsync().Result;
                total_order = Convert.ToInt32(result);
            }

            //get total buyers
            int total_buyers = 0;
            HttpResponseMessage responseTotalBuyers = await this.client.GetAsync($"api/order/total_buyers?timeFrom={date_filter}&timeTo={date_filter}&orderStatus=2");
            if (responseTotalBuyers.IsSuccessStatusCode)
            {
                var result = responseTotalBuyers.Content.ReadAsStringAsync().Result;
                total_buyers = Convert.ToInt32(result);
            }

            //get orders
            List<Order> orders = new List<Order>();
            HttpResponseMessage responseGetOrders = await this.client.GetAsync($"api/order/get_orders?timeFrom={time_from}&timeTo={date_now}");
            if (responseGetOrders.IsSuccessStatusCode)
            {
                var result = responseGetOrders.Content.ReadAsStringAsync().Result;
                orders = JsonConvert.DeserializeObject<List<Order>>(result);
            }
            ViewBag.dateFilter = date_filter;
            ViewBag.Url = "Home";
            ViewBag.TotalSales = total_sales;
            ViewBag.TotalOrders = total_order;
            ViewBag.TotalBuyers = total_buyers;
            ViewBag.Orders = orders.Take(10);
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin)
            {
                return RedirectToAction("Login", "Auth");
            }

            User user = new User();
            HttpResponseMessage responseAdmin = await this.client.GetAsync("api/user/" + id);
            if (responseAdmin.IsSuccessStatusCode)
            {
                var result = responseAdmin.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(result);

            }
            return View(user);
        }
       
        [HttpPost]
        public async Task<IActionResult> PostEdit(User user)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin)
            {
                return RedirectToAction("Login", "Auth");
            }
            HttpResponseMessage res = await client.GetAsync("api/user/email=" + user.Email);
            User userDb = new User();
            HttpResponseMessage responseAdmin = await this.client.GetAsync("api/user/" + user.UserId);
            if (responseAdmin.IsSuccessStatusCode)
            {
                var result = responseAdmin.Content.ReadAsStringAsync().Result;
                userDb = JsonConvert.DeserializeObject<User>(result);

            }
            if (userDb != null)
            {
                userDb.Email = user.Email;
                userDb.Admin.FirstName = user.Admin.FirstName;
                userDb.Admin.LastName = user.Admin.LastName;
                userDb.Admin.ContactNo = user.Admin.ContactNo;
                userDb.Admin.DateOfBirth = user.Admin.DateOfBirth;
                userDb.Admin.Gender = user.Admin.Gender;
                userDb.Admin.Address.Line = user.Admin.Address.Line;
                userDb.Admin.Address.City = user.Admin.Address.City;
                userDb.Admin.Address.Region = user.Admin.Address.Region;
                userDb.Admin.Address.PostCode = user.Admin.Address.PostCode;
                userDb.Admin.Address.Country = user.Admin.Address.Country;

                HttpResponseMessage responseUpdateAdmin = await client.PutAsJsonAsync("api/user/update", userDb);
                if (!responseUpdateAdmin.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("fail", await responseUpdateAdmin.Content.ReadAsStringAsync());
                    return View("Edit", userDb);
                }
            }
            TempData["success"] = "Profile updated successfully!";




            return RedirectToAction("Profile");
        }

        public async Task<IActionResult> Profile()
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin)
            {
                return RedirectToAction("Login", "Auth");
            }

            User user = new User();
            HttpResponseMessage responseAdmin = await this.client.GetAsync("api/user/" + (int)userId);
            if (responseAdmin.IsSuccessStatusCode)
            {
                var result = responseAdmin.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(result);

            }
            ViewBag.User = user;

            var message = TempData["success"];
            if (message != null)
            {
                ModelState.AddModelError("success", message.ToString());

            }
            return View();
        }
    }
}
