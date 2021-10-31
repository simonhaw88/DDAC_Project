using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace DDAC_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : Controller
    {
        private readonly IAmazonS3 amazonS3;
        private string bucketName = "ddactestbucket";
        public ImageController(IAmazonS3 amazonS3)
        {
            this.amazonS3 = amazonS3;

        }
        
        [HttpPost("postImage/{folder}")]
        public async Task<IActionResult> Post(string folder)
        {
            PutObjectResponse result = null;
            var content = Request.Form.Files;
            foreach(var file in content)
            {
                var putRequest = new PutObjectRequest()
                {
                    BucketName = bucketName + "/" + folder,
                    Key = file.FileName,
                    InputStream = file.OpenReadStream(),
                    ContentType = file.ContentType,
                };
                result = await this.amazonS3.PutObjectAsync(putRequest);
            }
            return Ok(result);
        }

        [HttpDelete("delete/{folder}/{fileName}")]
        public async Task<IActionResult> DeleteImage(string folder, string fileName)
        {
            DeleteObjectResponse result = null;
             
                var request = new DeleteObjectRequest()
                {
                    BucketName = bucketName + "/" + folder,
                    Key = fileName,
                };
                result = await this.amazonS3.DeleteObjectAsync(request);
           

            return Ok(result);
        }
    }
}
