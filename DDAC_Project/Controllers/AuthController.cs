using Microsoft.AspNetCore.Mvc;
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDAC_Project.Models;
using DDAC_Project.Data;
using System.Net.Http;
using System.Net.Http.Formatting;
using DDAC_Project.Helper;
using Newtonsoft.Json;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Http;
using Amazon.S3.Model;

namespace DDAC_Project.Controllers
{

    public class AuthController : Controller
    {
        AuthorAPI _api = new AuthorAPI();

        private readonly DDAC_Context _context;
        private HttpClient client;
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

        [HttpPost]
        public async Task<IActionResult> Login(User md)
        {
            var curr_password = md.Password;
            md.Password = encryption(curr_password);
            HttpResponseMessage res = await client.PostAsJsonAsync("api/user/verifyUser" , md);
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
                if(user.Role == (int)UserEnum.Customer)
                {
                    return RedirectToAction("Index", "Home");

                } else if(user.Role == (int)UserEnum.Admin)
                {
                    return RedirectToAction("Index", "Admin");

                } else if(user.Role == (int)UserEnum.Staff){
                    return RedirectToAction("Index", "Staff");
                }
               

            }

            return View();
        }
       
        [HttpPost]
        public async Task<IActionResult> Register(User md)
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
                    md.Password = encryption(curr_password);
                    HttpResponseMessage response = await client.PostAsJsonAsync(
                                   "api/user", md);
                    if (!response.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError("Global", "Failed to register.");
                    }
                    else
                    {
                        return View("Login");
                    }
                 }

            }

            return View();
        }

        public string encryption(String password)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] encrypt;
            UTF8Encoding encode = new UTF8Encoding();
            //encrypt the given password string into Encrypted data  
            encrypt = md5.ComputeHash(encode.GetBytes(password));
            StringBuilder encryptdata = new StringBuilder();
            //Create a new string by using the encrypted data  
            for (int i = 0; i < encrypt.Length; i++)
            {
                encryptdata.Append(encrypt[i].ToString());
            }
            return encryptdata.ToString();
        }
 
    }
}
