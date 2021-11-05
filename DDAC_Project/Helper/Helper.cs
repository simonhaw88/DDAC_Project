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
            //Client.BaseAddress = new Uri("https://localhost:44366/");
            Client.BaseAddress = new Uri("https://r1y6zb4lrl.execute-api.us-east-1.amazonaws.com/Prod/");
            return Client;
        }
    }
}
