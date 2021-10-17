﻿using Microsoft.AspNetCore.Mvc;
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
        public IActionResult Index()
        {
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
            HttpResponseMessage responseAlbum = await client.PostAsJsonAsync(
                                   "api/album", album);
           
            if (!responseAlbum.IsSuccessStatusCode )
            {
                 
                ModelState.AddModelError("fail", "Failed to create new album.");
            }
            else
            {
                Album albumObj = new Album();
                var result = responseAlbum.Content.ReadAsStringAsync().Result;
                albumObj = JsonConvert.DeserializeObject<Album>(result);
                string photoName = albumObj.AlbumId + "_" + album.FormFile.FileName.ToString();
                AlbumPhoto albumPhoto = new AlbumPhoto()
                {
                    Name = photoName,
                    AlbumId = albumObj.AlbumId
                };
                HttpResponseMessage responseAlbumPhoto = await client.PostAsJsonAsync(
                                       "api/album/albumPhoto", albumPhoto);
               
                    var form = new MultipartFormDataContent();
                    using (var fileStream = album.FormFile.OpenReadStream())
                    {
                        form.Add(new StreamContent(fileStream), "album.FormFile", photoName);
                        using (var response = await this.client.PostAsync("api/image/AlbumPhotos", form))
                        {
                            if (!response.IsSuccessStatusCode)
                            {
                                ModelState.AddModelError("fail", await response.Content.ReadAsStringAsync());  
                            }
                        }
                    }
               
                TempData["success"] =  "Album is created successfully!";
                return RedirectToAction("Create", "Album");
            }
            return View();
           
        }

       




    }
}
