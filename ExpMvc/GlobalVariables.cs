using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;

namespace ExpMvc
{
    public class GlobalVariables
    {
        public static HttpClient ExpApiClient =new HttpClient();
        static GlobalVariables()
        {
            ExpApiClient.BaseAddress = new Uri("https://localhost:44351/api/");
            ExpApiClient.DefaultRequestHeaders.Clear();
            ExpApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}