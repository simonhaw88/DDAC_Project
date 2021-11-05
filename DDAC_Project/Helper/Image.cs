using Amazon;
using Amazon.S3;
using Amazon.S3.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DDAC_Project.Helper
{
    public class Image
    {
        private static string bucketName = "ddactestbucket";
        private static readonly RegionEndpoint bucketRegion = RegionEndpoint.USEast1;
        private static IAmazonS3 client;
        public Image()
        {
            client = new AmazonS3Client(bucketRegion);
        }

        public static async Task<string> UploadImage(IFormFile form, string folder, string fileName)
        {
            try
            {
                client = new AmazonS3Client(bucketRegion);
                var putRequest = new PutObjectRequest()
                {
                    BucketName = bucketName + "/" + folder,
                    Key =  fileName,
                    InputStream = form.OpenReadStream(),
                    ContentType = form.ContentType,
                };
                 await client.PutObjectAsync(putRequest);
            }
            catch (AmazonS3Exception e)
            {
                return e.Message.ToString();
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            return "success";

        }
        public static async Task<string> DeleteImage(string folder, string fileName)
        {
            try {
                client = new AmazonS3Client(bucketRegion);

                var request = new DeleteObjectRequest()
                {
                    BucketName = bucketName + "/" + folder,
                    Key = fileName,
                };
                 await client.DeleteObjectAsync(request);

            }
            catch (AmazonS3Exception e)
            {
                return e.Message.ToString();
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            return "success";

        }
    }
}
