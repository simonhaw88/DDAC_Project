using DDAC_Project.Data;
using DDAC_Project.Helper;
using DDAC_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace DDAC_Project.Controllers
{
     public class AdminController : Controller
    {
        ApiHelper _api = new ApiHelper();
        private HttpClient client;
        private readonly DDAC_Context _context;
        private readonly string seassion_userId = "userId";
        private readonly string seassion_role = "role";

        public AdminController(DDAC_Context context)
        { 
            client = _api.Initial();
            _context = context;
        }

        public IActionResult Index()
        {
            ViewBag.Url = "Home";
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

            User userDb = new User();
            HttpResponseMessage responseAdmin = await this.client.GetAsync("api/user/" + user.UserId);
            if (responseAdmin.IsSuccessStatusCode)
            {
                var result = responseAdmin.Content.ReadAsStringAsync().Result;
                userDb = JsonConvert.DeserializeObject<User>(result);

            }
            if(userDb != null)
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
