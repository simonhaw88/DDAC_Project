using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using DDAC_Project.Models;
using DDAC_Project.Data;
using System.Net.Http;
using DDAC_Project.Helper;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using DDAC_Project.Factories;

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
            if (ModelState.IsValid)
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
