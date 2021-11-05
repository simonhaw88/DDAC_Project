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
    public class CustomerController : Controller
    {
        ApiHelper _api = new ApiHelper();
        private HttpClient client;
        private readonly string seassion_userId = "userId";
        private readonly string seassion_role = "role";

        public CustomerController()
        {
            client = _api.Initial();
        }

        public async Task<IActionResult> Profile()
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Customer)
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

        public async Task<IActionResult> Edit(int id)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Customer)
            {
                return RedirectToAction("Login", "Auth");
            }

            User user = new User();
            HttpResponseMessage responseCustomer = await this.client.GetAsync("api/user/" + id);
            if (responseCustomer.IsSuccessStatusCode)
            {
                var result = responseCustomer.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(result);

            }
            return View(user);
        }

        [HttpPost]
        public async Task<IActionResult> PostEdit(User user)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Customer)
            {
                return RedirectToAction("Login", "Auth");
            }
            User userDb = new User();
            HttpResponseMessage responseCustomer = await this.client.GetAsync("api/user/" + user.UserId);
            if (responseCustomer.IsSuccessStatusCode)
            {
                var result = responseCustomer.Content.ReadAsStringAsync().Result;
                userDb = JsonConvert.DeserializeObject<User>(result);

            }
            if (userDb != null)
            {
                userDb.Email = user.Email;
                userDb.Customer.FirstName = user.Customer.FirstName;
                userDb.Customer.LastName = user.Customer.LastName;
                userDb.Customer.ContactNo = user.Customer.ContactNo;
                userDb.Customer.DateOfBirth = user.Customer.DateOfBirth;
                userDb.Customer.Gender = user.Customer.Gender;
                userDb.Customer.Address.Line = user.Customer.Address.Line;
                userDb.Customer.Address.City = user.Customer.Address.City;
                userDb.Customer.Address.Region = user.Customer.Address.Region;
                userDb.Customer.Address.PostCode = user.Customer.Address.PostCode;
                userDb.Customer.Address.Country = user.Customer.Address.Country;

                HttpResponseMessage responseUpdateCustomer = await client.PutAsJsonAsync("api/user/update", userDb);
                if (!responseUpdateCustomer.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("fail", await responseUpdateCustomer.Content.ReadAsStringAsync());
                    return View("Edit", userDb);
                }
            }
            TempData["success"] = "Profile updated successfully!";


            return RedirectToAction("Profile");
        }
    }
}
