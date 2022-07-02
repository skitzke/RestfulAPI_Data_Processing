using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

namespace HDIDataAccess
{
    public static class APIHelper
    {

        public static HttpClient ApiClient { get; set; }

        public static void InitializeClient() 
        {
            ApiClient = new HttpClient();
            ApiClient.BaseAddress = new Uri("https://localhost:44313/");
            ApiClient.DefaultRequestHeaders.Accept.Clear();
            ApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
