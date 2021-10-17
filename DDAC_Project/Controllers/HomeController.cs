using DDAC_Project.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using DDAC_Project.Helper;
using System.Net.Http;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;
using System.IO;
using DDAC_Project.Data;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon;

namespace DDAC_Project.Controllers
{
    public class HomeController : Controller
    {
        private static IAmazonS3 amazonS3;
        AuthorAPI _api = new AuthorAPI();
        private HttpClient client;
        private readonly ILogger<HomeController> _logger;
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;

        public HomeController(ILogger<HomeController> logger)
        {
            amazonS3 = new AmazonS3Client(bucketRegion);

            client = _api.Initial();
            _logger = logger;
           
        }
        
        public IActionResult FileUploadForm()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> FileUploadForm([FromForm] FileUploadFormModal FileUpload)
        {
            string apiResponse;

            var form = new MultipartFormDataContent();
                using (var fileStream = FileUpload.FormFile.OpenReadStream())
                {
                    form.Add(new StreamContent(fileStream), "FileUpload.FormFile", FileUpload.FormFile.FileName);
                    using (var response = await this.client.PostAsync("api/image/AlbumPhotos", form))
                    {
                        response.EnsureSuccessStatusCode();
                        apiResponse = await response.Content.ReadAsStringAsync();
                    }
                }
            ModelState.AddModelError("Global", FileUpload.FormFile.FileName.ToString());
           


            return View();

        }

      
        public IActionResult Index()
        {
          
            // List<Author> author = new List<Author>();
            // HttpClient client = _api.Initial();
            // HttpResponseMessage res = await client.GetAsync("api/authors");
            // if (res.IsSuccessStatusCode)
            // {
            //     var result = res.Content.ReadAsStringAsync().Result;
            //     author = JsonConvert.DeserializeObject<List<Author>>(result);
            // }
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
