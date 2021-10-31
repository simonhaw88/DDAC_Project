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
using System.Text;
using Microsoft.AspNetCore.Http;

namespace DDAC_Project.Controllers
{
    public class AlbumController : Controller
    {
        ApiHelper _api = new ApiHelper();
        private HttpClient client;
        private readonly DDAC_Context _context;
        private readonly string seassion_userId = "userId";
        private readonly string seassion_role = "role";

        public AlbumController(DDAC_Context context)
        {
            client = _api.Initial();
            _context = context;
        }
        [HttpGet("album/delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin && role != (int)UserEnum.Staff)
            {
                return RedirectToAction("Login", "Auth");
            }

            HttpResponseMessage responseGetImage = await this.client.GetAsync(
                                      $"api/albumphoto/albumId={id}");
            AlbumPhoto albumPhoto = new AlbumPhoto();
            if (responseGetImage.IsSuccessStatusCode)
            {
                var result = responseGetImage.Content.ReadAsStringAsync().Result;
                albumPhoto = JsonConvert.DeserializeObject<AlbumPhoto>(result);
                //delete existing image
                HttpResponseMessage responseDeleteImage = await this.client.DeleteAsync(
                                   $"api/image/delete/album/{albumPhoto.Name}");

                if (!responseDeleteImage.IsSuccessStatusCode)
                {
                    TempData["fail"] = await responseDeleteImage.Content.ReadAsStringAsync();
                    return RedirectToAction("adminsearchalbum");

                }
            }
            HttpResponseMessage responseDelete = await this.client.DeleteAsync(
                                      $"api/album/delete/{id}");
            
            if (!responseDelete.IsSuccessStatusCode)
            {
                TempData["fail"] = await responseDelete.Content.ReadAsStringAsync();
                return RedirectToAction("adminsearchalbum");

            }
            TempData["success"] = "Delete successfully";
            return RedirectToAction("adminsearchalbum");
        }

        [HttpPost("album/postEdit")]
        public async Task<IActionResult> PostEdit(Album ab)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin && role != (int)UserEnum.Staff)
            {
                return RedirectToAction("Login", "Auth");
            }

            //update existing album
            HttpResponseMessage responseUpdateAlbum = await client.PutAsJsonAsync("api/album/updateAlbum", ab);
            if (!responseUpdateAlbum.IsSuccessStatusCode)
            {
                 TempData["fail"] = await responseUpdateAlbum.Content.ReadAsStringAsync();
                 return RedirectToAction("Edit", new { id = ab.AlbumId });

            }

            //update tracks
            if (ab.TrackNames != null)
            {
                HttpResponseMessage responseDeleteAll = await client.DeleteAsync($"api/track/delete/albumId/{ab.AlbumId}");

                foreach (var track in ab.TrackNames)
                {
                    Track trackM = new Track() { Name = track, AlbumId = ab.AlbumId };
                    HttpResponseMessage responseTrack = await this.client.PostAsJsonAsync(
                                       "api/track/postTrack", trackM);
                    if (!responseTrack.IsSuccessStatusCode)
                    {
                        TempData["fail"] = await responseTrack.Content.ReadAsStringAsync();
                        return RedirectToAction("Edit", new { id = ab.AlbumId });
                    }

                }
            }

            if (ab.FormFile != null)
            {
                //get albumPhoto
                HttpResponseMessage responseGetImage = await this.client.GetAsync(
                                       $"api/albumphoto/albumId={ab.AlbumId}");
                AlbumPhoto albumPhoto = new AlbumPhoto();
                if (responseGetImage.IsSuccessStatusCode)
                {
                    var result = responseGetImage.Content.ReadAsStringAsync().Result;
                    albumPhoto = JsonConvert.DeserializeObject<AlbumPhoto>(result);
                    //delete existing image from s3 bucket
                    HttpResponseMessage responseDeleteImage = await this.client.DeleteAsync(
                                       $"api/image/delete/album/{albumPhoto.Name}");
                    if (!responseDeleteImage.IsSuccessStatusCode)
                    {
                        TempData["fail"] = await responseDeleteImage.Content.ReadAsStringAsync();
                        return RedirectToAction("Edit", new { id = ab.AlbumId });

                    }
                }
                else
                {
                    TempData["fail"] = await responseGetImage.Content.ReadAsStringAsync();
                    return RedirectToAction("Edit", new { id = ab.AlbumId });
                }

                var plainTextBytes = Convert.ToBase64String(Encoding.UTF8.GetBytes(ab.FormFile.FileName)); 
              
                string photoName = ab.AlbumId + "_" + plainTextBytes.ToString();
                albumPhoto.Name = photoName;

                //update album photo's name
                HttpResponseMessage responseAlbumPhoto = await this.client.PutAsJsonAsync(
                                       "api/albumphoto/updateAlbumPhoto", albumPhoto);
                if (!responseAlbumPhoto.IsSuccessStatusCode)
                {
                    TempData["fail"] = await responseAlbumPhoto.Content.ReadAsStringAsync();
                    return RedirectToAction("Edit", new { id = ab.AlbumId });

                }
                //upload new image to s3 bucket
                var form = new MultipartFormDataContent();
                using (var fileStream = ab.FormFile.OpenReadStream())
                {
                    form.Add(new StreamContent(fileStream), "ab.FormFile", photoName);
                    using (var response = await this.client.PostAsync("api/image/postImage/album", form))
                    {
                        if (!response.IsSuccessStatusCode)
                        {
                            TempData["fail"] = await response.Content.ReadAsStringAsync();
                            return RedirectToAction("Edit", new { id = ab.AlbumId });
                        }
                         
                    }
                }
            }
            
            TempData["success"] = "Update successfully";
             return RedirectToAction("adminsearchalbum");
        }

        [HttpGet("album/edit/{id}")]
        public async Task<IActionResult> Edit(int id)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin && role != (int)UserEnum.Staff)
            {
                return RedirectToAction("Login", "Auth");
            }
            Album album = new Album();
            HttpResponseMessage responseAlbumsPag = await this.client.GetAsync("api/album/" + id);
            if (responseAlbumsPag.IsSuccessStatusCode)
            {
                var result = responseAlbumsPag.Content.ReadAsStringAsync().Result;
                album = JsonConvert.DeserializeObject<Album>(result);

            }
            
            List<AlbumCategory> albumCategory = new List<AlbumCategory>();
            HttpResponseMessage res = await this.client.GetAsync("api/albumcategory");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                albumCategory = JsonConvert.DeserializeObject<List<AlbumCategory>>(result);
            }
            ViewBag.AlbumCategory = albumCategory;

            var message = TempData["fail"];
            if (message != null)
            {
                ModelState.AddModelError("fail", message.ToString());

            }

            return View(album);
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

        [ActionName("adminsearchalbum")]
        [HttpGet("admin/album/search")]
        public async Task<IActionResult> AdminSearch(string value, int pageNumber = 1)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin && role != (int)UserEnum.Staff)
            {
                return RedirectToAction("Login", "Auth");
            }

            List<Album> albumPag = new List<Album>();
            int pageSize = 15;
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            HttpResponseMessage responseAlbumsPag = await this.client.GetAsync("api/album/search?type=name" + "&value=" + value);
            if (responseAlbumsPag.IsSuccessStatusCode)
            {
                var result = responseAlbumsPag.Content.ReadAsStringAsync().Result;
                albumPag = JsonConvert.DeserializeObject<List<Album>>(result);

            }
            ViewBag.AlbumsPag = albumPag.Skip(ExcludeRecords).Take(pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.totalItems = albumPag.Count;
            ViewBag.Url = "Albums";

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
            return View("AdminSearch");

        }

        [HttpGet("album/search")]
        public async Task<IActionResult> Search(string type, string value, int pageNumber= 1 )
        {
            List<Album> albumPag = new List<Album>();
            int pageSize = 15;
            int ExcludeRecords = (pageSize * pageNumber) - pageSize;
            HttpResponseMessage responseAlbumsPag = await this.client.GetAsync("api/album/search?type="+ type + "&value=" + value );
            if (responseAlbumsPag.IsSuccessStatusCode)
            {
                var result = responseAlbumsPag.Content.ReadAsStringAsync().Result;
                albumPag = JsonConvert.DeserializeObject<List<Album>>(result);

            }
            ViewBag.AlbumsPag = albumPag.Skip(ExcludeRecords).Take(pageSize);
            ViewBag.pageNumber = pageNumber;
            ViewBag.pageSize = pageSize;
            ViewBag.totalItems = albumPag.Count ;

            List<AlbumCategory> albumCategory = new List<AlbumCategory>();
            HttpResponseMessage res = await this.client.GetAsync("api/albumcategory");
            if (res.IsSuccessStatusCode)
            {
                var result = res.Content.ReadAsStringAsync().Result;
                albumCategory = JsonConvert.DeserializeObject<List<AlbumCategory>>(result);
            }
            ViewBag.AlbumCategory = albumCategory;

            return View();

        }
        public async Task<IActionResult> Create()
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin && role != (int)UserEnum.Staff)
            {
                return RedirectToAction("Login", "Auth");
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
            var message = TempData["fail"];
            if(message != null)
            {
                ModelState.AddModelError("fail", message.ToString());

            }
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Album album)
        {
            var userId = HttpContext.Session.GetInt32(seassion_userId);
            var role = HttpContext.Session.GetInt32(seassion_role);
            if (!userId.HasValue || role != (int)UserEnum.Admin && role != (int)UserEnum.Staff)
            {
                return RedirectToAction("Login", "Auth");
            }

            List<AlbumCategory> albumCategory = new List<AlbumCategory>();
            HttpResponseMessage res = await client.GetAsync("api/albumcategory");
            if (res.IsSuccessStatusCode)
            {
                var result_albumCategory = res.Content.ReadAsStringAsync().Result;
                albumCategory = JsonConvert.DeserializeObject<List<AlbumCategory>>(result_albumCategory);
            }
            ViewBag.AlbumCategory = albumCategory;

            if (!ModelState.IsValid)
            {
                return View();
            }
                if (album.TrackNames != null) {
                foreach (var track in album.TrackNames)
                {
                    Track trackM = new Track() { Name = track };
                    album.Tracks.Add(trackM);
                }
            }
            //add new album and tracks
            HttpResponseMessage responseAlbum = await this.client.PostAsJsonAsync(
                                   "api/album/postAlbum", album);

            if (!responseAlbum.IsSuccessStatusCode)
            {

                ModelState.AddModelError("fail", await responseAlbum.Content.ReadAsStringAsync());
                return View();
            }
            var result_album = responseAlbum.Content.ReadAsStringAsync().Result;
            Album albumObj = JsonConvert.DeserializeObject<Album>(result_album);
            var plainTextBytes = Convert.ToBase64String(Encoding.UTF8.GetBytes(album.FormFile.FileName));  

            string photoName = albumObj.AlbumId + "_" + plainTextBytes;
            AlbumPhoto albumPhoto = new AlbumPhoto()
            {
                Name = photoName,
                AlbumId = albumObj.AlbumId
            };
            //add new album photo
            HttpResponseMessage responseAlbumPhoto = await this.client.PostAsJsonAsync(
                                   "api/albumphoto/postAlbumPhoto", albumPhoto);
            
            if (await responseAlbumPhoto.Content.ReadAsStringAsync() == null)
            {

                ModelState.AddModelError("fail", await responseAlbumPhoto.Content.ReadAsStringAsync());
                return View();
            }

            //upload to s3 bucket
            var form = new MultipartFormDataContent();
            using (var fileStream = album.FormFile.OpenReadStream())
            {
                form.Add(new StreamContent(fileStream), "album.FormFile", photoName);
                using (var response = await this.client.PostAsync("api/image/postImage/album", form))
                {
                    if (!response.IsSuccessStatusCode)
                    {
                        ModelState.AddModelError("fail", await response.Content.ReadAsStringAsync());
                        return View();
                    }
                }
            }

            TempData["success"] = "Album created successfully";
                return RedirectToAction("adminsearchalbum");
            }
    }
}
