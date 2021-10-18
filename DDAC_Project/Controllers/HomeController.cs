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

      
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 5)
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

            List<Album> album = new List<Album>();
            HttpResponseMessage responseAlbums = await client.GetAsync("api/album/" + 0 + "/" +6);
            if (responseAlbums.IsSuccessStatusCode)
            {
                var result = responseAlbums.Content.ReadAsStringAsync().Result;
                album = JsonConvert.DeserializeObject<List<Album>>(result);
            }
            ViewBag.Albums = album;

            List<Album> albumPag = new List<Album>();
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
             HttpResponseMessage responseAlbumsPag = await client.GetAsync("api/album/"+ ExcludeRecords + "/"+pageSize);
            if (responseAlbumsPag.IsSuccessStatusCode)
            {
                var result = responseAlbumsPag.Content.ReadAsStringAsync().Result;
                albumPag = JsonConvert.DeserializeObject<List<Album>>(result);
                
            }
            ViewBag.AlbumsPag = albumPag;
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.totalItems = albumPag.Count + 1;
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
