using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DDAC_Project.Models;
using DDAC_Project.Data;
using System.Net.Http;
using DDAC_Project.Helper;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using DDAC_Project.Factories;
using System.Collections.Generic;
using System.Linq;

namespace DDAC_Project.Controllers
{

    public class AuthController : Controller
    {
        ApiHelper _api = new ApiHelper();

        private readonly DDAC_Context _context;
        private HttpClient client;
        private readonly string seassion_userId = "userId";
        private readonly string seassion_role = "role";

        public AuthController(DDAC_Context context)
        {
            client = _api.Initial();
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Register()
        {
            return View();
        }

        [ActionName("forgotpassword")]
        public IActionResult ForgotPassword()
        {

            return View();
        }

        [ActionName("postforgotpassword")]
        [HttpPost]
        public async Task<IActionResult> PostForgotPassword(User user)
        {
            List<User> userDb = new List<User>();
            HttpResponseMessage res = await client.GetAsync("api/user/search?email=" + user.Email);

            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                userDb = JsonConvert.DeserializeObject<List<User>>(result);
                if (!userDb.Any())
                {
                    ModelState.AddModelError("fail", "User not found");
                    return View("ForgotPassword");
                }
                else
                {
                    User userM = userDb.First();
                    if (userM.SecurityAns != user.SecurityAns)
                    {
                        ModelState.AddModelError("fail", "Invalid credentials");
                        return View("ForgotPassword");
                    }
                    HttpContext.Session.SetInt32("temp_id", userM.UserId);
                }
            }
            return RedirectToAction("SetNewPassword");
        }
        
        public IActionResult SetNewPassword()
        {
            return View("Set_new_pasasword");
        }

        [ActionName("postnewpassword")]
        [HttpPost]
        public async Task<IActionResult> PostNewPassword(string newPassword, string confirmNewPassword)
        {
            if (!ModelState.IsValid)
            {
                return View("Set_new_pasasword");
            }

            if (newPassword != confirmNewPassword)
            {
                ModelState.AddModelError("confirmNewPassword", "New Password and confirm new password must be same!");
                return View("Set_new_pasasword");
            }
            else
            {
                var userId = HttpContext.Session.GetInt32("temp_id");
                if (!userId.HasValue)
                {
                    return RedirectToAction("ForgotPassword");
                }

                HttpResponseMessage responseGetUser = await this.client.GetAsync("api/user/" + (int)userId);
                User user = new User();
                if (responseGetUser.IsSuccessStatusCode)
                {
                    var result = responseGetUser.Content.ReadAsStringAsync().Result;
                    user = JsonConvert.DeserializeObject<User>(result);

                    if (user == null)
                    {
                        ModelState.AddModelError("fail", "User not found");
                        return View("Set_new_pasasword");
                    }
                    user.Password = Password.encryption(newPassword);
                    HttpResponseMessage responseUpdate = await this.client.PutAsJsonAsync(
                                   "api/user/update", user);
                    if (!responseUpdate.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError("fail", await responseUpdate.Content.ReadAsStringAsync());
                        return View("Set_new_pasasword");
                    }

                }
                else
                {
                    ModelState.AddModelError("fail", await responseGetUser.Content.ReadAsStringAsync());
                }
            }
            return View("Login");
        }

        [ActionName("password")]
        public IActionResult ChangePassword()
        {
            return View("Password");
        }

        [ActionName("editpassword")]
        [HttpPost]
        public async Task<IActionResult> PostEditPassword(string password, string newPassword, string confirmNewPassword)
        {
            if (ModelState.IsValid)
            {
                var userId = HttpContext.Session.GetInt32(seassion_userId);
                var role = HttpContext.Session.GetInt32(seassion_role);
                if (!userId.HasValue)
                {
                    return RedirectToAction("Login", "Auth");
                }

                if (newPassword != confirmNewPassword)
                {
                    ModelState.AddModelError("confirmNewPassword", "New Password and confirm new password must be same!");
                    return View("Password");
                }
                else
                {
                    HttpResponseMessage responseGetUser = await this.client.GetAsync("api/user/" + (int)userId);
                    User user = new User();
                    if (responseGetUser.IsSuccessStatusCode)
                    {
                        var result = responseGetUser.Content.ReadAsStringAsync().Result;
                        user = JsonConvert.DeserializeObject<User>(result);

                        string encryptedPassword = Password.encryption(password);
                        if (user.Password == encryptedPassword)
                        {
                            user.Password = Password.encryption(newPassword);
                            HttpResponseMessage responseUpdate = await this.client.PutAsJsonAsync(
                                           "api/user/update", user);
                            if (!responseUpdate.IsSuccessStatusCode)
                            {
                                ModelState.AddModelError("fail", await responseUpdate.Content.ReadAsStringAsync());
                                return View("Password");
                            }
                        }
                        else
                        {
                            ModelState.AddModelError("fail", "Current password invalid.");
                            return View("Password");
                        }
                    }
                }
                ModelState.AddModelError("success", "Password updated successfully");
            }
            return View("Password");
        }

        [HttpPost]
        public async Task<IActionResult> Login(User md)
        {
            var curr_password = md.Password;
            md.Password = Password.encryption(curr_password);
            HttpResponseMessage res = await client.PostAsJsonAsync("api/user/verifyUser", md);
            var result = res.Content.ReadAsStringAsync().Result;
            if (result == "")
            {
                ModelState.AddModelError("Global", "Invalid User");
            }
            else
            {
                User user = new User();
                user = JsonConvert.DeserializeObject<User>(result);
                HttpContext.Session.SetInt32("userId", user.UserId);
                HttpContext.Session.SetInt32("role", user.Role);
                if (user.Role == (int)UserEnum.Customer)
                {
                    return RedirectToAction("Index", "Home");

                }
                else if (user.Role == (int)UserEnum.Admin)
                {
                    return RedirectToAction("Index", "Admin");

                }
                else if (user.Role == (int)UserEnum.Staff)
                {
                    return RedirectToAction("Index", "Staff");
                }

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User md)
        {
            if (ModelState.IsValid)
            {
                HttpResponseMessage res = await client.GetAsync("api/user/email=" + md.Email);
                if (res.IsSuccessStatusCode)
                {
                    var exist = res.Content.ReadAsStringAsync().Result;
                    if (exist == "true")
                    {
                        ModelState.AddModelError("Email", "Email existed, please try another email.");
                    }
                    else
                    {
                        var curr_password = md.Password;
                        md.Password = Password.encryption(curr_password);
                        HttpResponseMessage response = await client.PostAsJsonAsync(
                                       "api/user", UserFactory.Create(md.Role, md));
                        if (!response.IsSuccessStatusCode)
                        {
                            ModelState.AddModelError("Global", await response.Content.ReadAsStringAsync());
                        }
                        else
                        {
                            return View("Login");
                        }
                    }
                }
            }
            return View();
        }

    }
}
