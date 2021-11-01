using DDAC_Project.Data;
using DDAC_Project.Helper;
using DDAC_Project.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DDAC_Project.Controllers
{
    public class UserController : Controller
    {
        ApiHelper _api = new ApiHelper();
        private HttpClient client;
        private readonly string seassion_userId = "userId";

        public UserController()
        {
            client = _api.Initial();
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            string status;
            string message;
            HttpResponseMessage responseDeleteUser = await this.client.DeleteAsync(
                                  $"api/user/delete/{id}");

            if (!responseDeleteUser.IsSuccessStatusCode)
            {
                status = "Fail";
                message = "Failed to delete user.";

            }
            else
            {
                status = "Success";
                message = "User deleted successfully.";

            }

            return Json(new { status = status, message = message });
        }
        [HttpGet("user/updatestatus/{type}/{id}")]
        public async Task<IActionResult> UpdateStatus(int id, string type)
        {
            string status = null;
            string message = null;
            User user = new User();
            HttpResponseMessage responseAlbumsPag = await client.GetAsync("api/user/" + id);
            if (responseAlbumsPag.IsSuccessStatusCode)
            {
                var result = responseAlbumsPag.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(result);

            }
            user.Status = type == "deactivate" ? (int)UserStatusEnum.Inactive : (int)UserStatusEnum.Active;
            HttpResponseMessage responseUpdateUser = await client.PutAsJsonAsync("api/user/update", user);
            if (!responseUpdateUser.IsSuccessStatusCode)
            {
                status = "Fail";
                message = "Failed to deactive user.";

            }
            status = "Success";
            message = type == "deactivate" ? "User has been deactivated." : "User has been activated";

            return Json(new { status = status, message = message});
        }

        [ActionName("Regeneratepassword")]
        [HttpGet]
        public async Task<IActionResult> RegeneratePassword(int id)
        {
             
            string newPassword = Password.CreateRandomPassword();
            User user = new User();
            HttpResponseMessage responseAlbumsPag = await client.GetAsync("api/user/" + id);
            if (responseAlbumsPag.IsSuccessStatusCode)
            {
                var result = responseAlbumsPag.Content.ReadAsStringAsync().Result;
                user = JsonConvert.DeserializeObject<User>(result);

            }
            user.Password = Password.encryption(newPassword);
            HttpResponseMessage responseUpdateUser = await client.PutAsJsonAsync("api/user/update", user);
            if (!responseUpdateUser.IsSuccessStatusCode)
            {
                newPassword = null;

            }

            return Json(new { password = newPassword });
        }
    }
}
