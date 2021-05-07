using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace Library.Api.Client
{
    class UrlConfig
    {
        public static HttpClient WebApiClient = new HttpClient();
        static UrlConfig()
        {
            WebApiClient.BaseAddress = new Uri("https://localhost:44319/api/");
            WebApiClient.DefaultRequestHeaders.Clear();
            WebApiClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }
    }
}
