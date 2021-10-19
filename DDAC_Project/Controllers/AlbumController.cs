using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DDAC_Project.Models;
using DDAC_Project.Helper;
using System.Net.Http;
using DDAC_Project.Data;
using Newtonsoft.Json;

namespace DDAC_Project.Controllers
{
    public class AlbumController : Controller
    {
        AuthorAPI _api = new AuthorAPI();
        private HttpClient client;
        private readonly DDAC_Context _context;

        public AlbumController(DDAC_Context context)
        {
            client = _api.Initial();
            _context = context;
        }

        [HttpGet("album/edit/{id}")]
        public async Task<IActionResult> Edit(int id)
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

            Album album = new Album();
            HttpResponseMessage responseAlbumsPag = await client.GetAsync("api/album/" + id);
            if (responseAlbumsPag.IsSuccessStatusCode)
            {
                var result = responseAlbumsPag.Content.ReadAsStringAsync().Result;
                album = JsonConvert.DeserializeObject<Album>(result);

            }
             return View(album);
        }

        [HttpGet("album")]
        public async Task<IActionResult> Index(int pageNumber = 1, int pageSize = 15)
        {

            List<Album> albumPag = new List<Album>();
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            HttpResponseMessage responseAlbumsPag = await client.GetAsync("api/album");
            if (responseAlbumsPag.IsSuccessStatusCode)
            {
                var result = responseAlbumsPag.Content.ReadAsStringAsync().Result;
                albumPag = JsonConvert.DeserializeObject<List<Album>>(result);

            }
            ViewBag.AlbumsPag = albumPag.Skip(ExcludeRecords).Take(pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.totalItems = albumPag.Count;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Info(int id)
        {
            Album album = new Album();
            HttpResponseMessage responseAlbums = await client.GetAsync("api/album/" + id);
            if (responseAlbums.IsSuccessStatusCode)
            {
                var result = responseAlbums.Content.ReadAsStringAsync().Result;
                album = JsonConvert.DeserializeObject<Album>(result);
            }
            ViewBag.Albums = album;
            return View();
        }

        [HttpGet("search/{type}")]
        public async Task<IActionResult> Search(string type, string value, int pageNumber= 1, int pageSize=15 )
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
            //https://localhost:5001/search/category?value=2&&pageNumber=1&&pageSize=2
            List<Album> albumPag = new List<Album>();
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            HttpResponseMessage responseAlbumsPag = await client.GetAsync("api/album/"+ type +"/" + value );
            if (responseAlbumsPag.IsSuccessStatusCode)
            {
                var result = responseAlbumsPag.Content.ReadAsStringAsync().Result;
                albumPag = JsonConvert.DeserializeObject<List<Album>>(result);

            }
            ViewBag.AlbumsPag = albumPag.Skip(ExcludeRecords).Take(pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.totalItems = albumPag.Count ;
            return View();

        }
        public async Task<IActionResult> Create()
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
            var message = TempData["success"];
            if(message != null)
            {
                ModelState.AddModelError("success", message.ToString());

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Album album)
        {
            bool fail = false;
            HttpResponseMessage responseAlbum = await this.client.PostAsJsonAsync(
                                   "api/album", album);
           
            if (!responseAlbum.IsSuccessStatusCode )
            {
                 
                ModelState.AddModelError("fail", "Failed to create new album.");
            }
            else
            {
                var result = responseAlbum.Content.ReadAsStringAsync().Result;
                Album albumObj = JsonConvert.DeserializeObject<Album>(result);
                string photoName = albumObj.AlbumId + "_" + album.FormFile.FileName.ToString();
                AlbumPhoto albumPhoto = new AlbumPhoto()
                {
                    Name = photoName,
                    AlbumId = albumObj.AlbumId
                };
                HttpResponseMessage responseAlbumPhoto = await this.client.PostAsJsonAsync(
                                       "api/albumphoto/album", albumPhoto);
                var form = new MultipartFormDataContent();
                using (var fileStream = album.FormFile.OpenReadStream())
                {
                    form.Add(new StreamContent(fileStream), "album.FormFile", photoName);
                    using (var response = await this.client.PostAsync("api/image/album", form))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            fail = true;
                            ModelState.AddModelError("fail", await response.Content.ReadAsStringAsync());  
                        }
                    }
                }
                foreach(var track in album.TrackNames)
                {
                    Track trackM = new Track() { Name = track, AlbumId = albumObj.AlbumId };
                    HttpResponseMessage responseTrack = await this.client.PostAsJsonAsync(
                                       "api/track", trackM);
                    if (!responseTrack.IsSuccessStatusCode)
                    {
                        fail = true;
                        ModelState.AddModelError("fail", await responseTrack.Content.ReadAsStringAsync());
                    }
                }
                

                if (!fail)
                {
                    TempData["success"] = "Album is created successfully!";
                    return RedirectToAction("Create", "Album");
                }
               
            }
            List<AlbumCategory> albumCategory = new List<AlbumCategory>();
            HttpClient client = _api.Initial();
            HttpResponseMessage res = await client.GetAsync("api/albumcategory");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                albumCategory = JsonConvert.DeserializeObject<List<AlbumCategory>>(result);
            }
            ViewBag.AlbumCategory = albumCategory; 
            return View();
           
        }

    }
}
