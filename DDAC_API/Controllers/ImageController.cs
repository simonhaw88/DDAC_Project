using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
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
        
        [HttpPost]
        public async Task<IActionResult> Post()
        {
            PutObjectResponse result = null;
            var content = Request.Form.Files;
            foreach(var file in content)
            {
                var putRequest = new PutObjectRequest()
                {
                    BucketName = bucketName,
                    Key = file.FileName,
                    InputStream = file.OpenReadStream(),
                    ContentType = file.ContentType,
                };
                result = await this.amazonS3.PutObjectAsync(putRequest);
            }
            return Ok(result);
        }
    }
}
