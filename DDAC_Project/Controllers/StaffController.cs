using DDAC_Project.Data;
using DDAC_Project.Factories;
using DDAC_Project.Helper;
using DDAC_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DDAC_Project.Controllers
{
    public class StaffController : Controller
    {
        ApiHelper _api = new ApiHelper();
        private HttpClient client;
        private readonly DDAC_Context _context;
        private readonly string seassion_userId = "userId";
        private readonly string seassion_role = "role";

        public StaffController(DDAC_Context context)
        {
            client = _api.Initial();
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Staff)
            {
                return RedirectToAction("Login", "Auth");
            }
            ViewBag.Url = "Home";
            return View();
        }

        public async Task<IActionResult> Edit(int id)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Staff)
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
            if (!userId.HasValue || role != (int)UserEnum.Staff)
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
            if (userDb != null)
            {
                userDb.Email = user.Email;
                userDb.Staff.FirstName = user.Staff.FirstName;
                userDb.Staff.LastName = user.Staff.LastName;
                userDb.Staff.ContactNo = user.Staff.ContactNo;
                userDb.Staff.DateOfBirth = user.Staff.DateOfBirth;
                userDb.Staff.Gender = user.Staff.Gender;
                userDb.Staff.Address.Line = user.Staff.Address.Line;
                userDb.Staff.Address.City = user.Staff.Address.City;
                userDb.Staff.Address.Region = user.Staff.Address.Region;
                userDb.Staff.Address.PostCode = user.Staff.Address.PostCode;
                userDb.Staff.Address.Country = user.Staff.Address.Country;

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
            if (!userId.HasValue || role != (int)UserEnum.Staff)
            {
                return RedirectToAction("Login", "Auth");
            }
            
            User user = new User();
            HttpResponseMessage responseStaff = await this.client.GetAsync("api/user/" + (int)userId);
            if (responseStaff.IsSuccessStatusCode)
            {
                var result = responseStaff.Content.ReadAsStringAsync().Result;
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

        [HttpPost]
        public async Task<IActionResult> Add(string email)
        {
            string status = null;
            string message = null;
            string acc_email = null;
            string acc_password = null;
            string randomPassword = Password.CreateRandomPassword();

            HttpResponseMessage res = await client.GetAsync("api/user/email=" + email);
            if (res.IsSuccessStatusCode)
            {
                var exist = res.Content.ReadAsStringAsync().Result;
                if (exist == "true")
                {
                    status = "Fail";
                    message = "Email existed !";
                }
                else
                {
                    User user = new User() { Email = email, Password = Password.encryption(randomPassword)};
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                                   "api/user", UserFactory.Create((int)UserEnum.Staff, user));
                    
                    if (!response.IsSuccessStatusCode)
                    {
                        status = "Fail";
                        message = "Failed to create staff.";
                    }
                    else
                    {
                        var result = response.Content.ReadAsStringAsync().Result;
                        user = JsonConvert.DeserializeObject<User>(result);
                        acc_email = email;
                        acc_password = randomPassword;
                        status = "Success";
                        message = "Staff account created successfully.";
                    }   
                }
            } 
            else
            {
                status = "Fail";
                message = "Failed to create staff.";
            }
           
            return Json(new { status = status, message= message, acc_email = acc_email , acc_password = acc_password});
        }

        [HttpGet("staff/search")]
        public async Task<IActionResult> Search(string value, int pageNumber = 1)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin)
            {
                return RedirectToAction("Login", "Auth");
            }

            List<User> users = new List<User>();
            int pageSize = 15;
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            HttpResponseMessage responseStaffs = await client.GetAsync("api/user/search?role=" +(int)UserEnum.Staff + "&email=" + value);
            
            if (responseStaffs.IsSuccessStatusCode)
            {
                var result = responseStaffs.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(result);
 
            }
            ViewBag.users = users.Skip(ExcludeRecords).Take(pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.totalItems = users.Count;
            ViewBag.Url = "Staff";

            var fail = TempData["fail"];
            var success = TempData["success"];
            if (fail != null)
            {
                ModelState.AddModelError("fail", fail.ToString());

            }

            if (success != null)
            {
                ModelState.AddModelError("success", success.ToString());

            }
            return View();

        }
    }
}
