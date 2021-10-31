using DDAC_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DDAC_Project.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using Amazon.S3;
using Amazon;

namespace DDAC_Project.Controllers
{
    public class HomeController : Controller
    {
        private static IAmazonS3 amazonS3;
        ApiHelper _api = new ApiHelper();
        private HttpClient client;
        private readonly ILogger<HomeController> _logger;
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;

        public HomeController(ILogger<HomeController> logger)
        {
            amazonS3 = new AmazonS3Client(bucketRegion);

            client = _api.Initial();
            _logger = logger;
           
        }
        
        public async Task<IActionResult> Contact()
        {
            List<User> users = new List<User>();
            HttpResponseMessage responseAdmins = await client.GetAsync("api/user/search?role=" + (int)UserEnum.Admin);

            if (responseAdmins.IsSuccessStatusCode)
            {
                var result = responseAdmins.Content.ReadAsStringAsync().Result;
                users = JsonConvert.DeserializeObject<List<User>>(result);

            }
            ViewBag.User = users.First();
            ViewBag.Url = "Contact Admin";
            return View();
        }      
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 15)
        {
            List<AlbumCategory> albumCategory = new List<AlbumCategory>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/albumcategory");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                albumCategory = JsonConvert.DeserializeObject<List<AlbumCategory>>(result);
            }
            ViewBag.AlbumCategory = albumCategory;

           
            List<Album> albumPag = new List<Album>();
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            HttpResponseMessage responseAlbumsPag = await client.GetAsync("api/album");
            if (responseAlbumsPag.IsSuccessStatusCode)
            {
                var result = responseAlbumsPag.Content.ReadAsStringAsync().Result;
                albumPag = JsonConvert.DeserializeObject<List<Album>>(result);
                
            }
            ViewBag.AlbumsPag = albumPag.Skip(ExcludeRecords).Take(pageSize);
            ViewBag.Albums = albumPag.Take(6);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.totalItems = albumPag.Count;
            ViewBag.Url = "Home";
            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login", "Auth");
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}
