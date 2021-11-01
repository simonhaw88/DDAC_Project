using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DDAC_Project.Helper
{
    public class ApiHelper
    {
        public HttpClient Initial()
        {
            var Client = new HttpClient();
            Client.BaseAddress = new Uri("https://kq6yw87lq7.execute-api.ap-southeast-1.amazonaws.com/Prod/");
            return Client;
        }
    }
}
