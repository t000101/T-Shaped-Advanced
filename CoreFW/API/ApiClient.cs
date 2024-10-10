using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;

namespace CoreFW.API
{
    public class ApiClient
    {
        private static HttpClient httpClient = new HttpClient();

        public static HttpResponseMessage Get(string url, string parameters = null, HttpRequestHeaders headers = null)
        {
            string queryUrl = url;
            if (parameters != null)
            {
                UriBuilder builder = new UriBuilder(url);
                builder.Query = parameters;
                queryUrl = builder.ToString();
            }

            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, queryUrl);
            request = AppendHeadersToRequest(request, headers);

            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            return response;
        }

        public static HttpResponseMessage Post(string url, string bodyJson, HttpRequestHeaders headers = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
            request = AppendHeadersToRequest(request, headers);
            StringContent data = new StringContent(bodyJson, Encoding.UTF8, "application/json");
            request.Content = data;

            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            return response;
        }

        public static HttpResponseMessage Put(string url, string bodyJson, HttpRequestHeaders headers = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);
            request = AppendHeadersToRequest(request, headers);
            StringContent data = new StringContent(bodyJson, Encoding.UTF8, "application/json");
            request.Content = data;

            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            return response;
        }

        public static HttpResponseMessage Delete(string url, HttpRequestHeaders headers = null)
        {
            HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
            request = AppendHeadersToRequest(request, headers);

            HttpResponseMessage response = httpClient.SendAsync(request).Result;
            return response;
        }

        private static HttpRequestMessage AppendHeadersToRequest(HttpRequestMessage request, HttpRequestHeaders headers)
        {
            if (headers == null) return request;

            foreach(var header in headers)
            {
                request.Headers.Add(header.Key, header.Value);
            }

            return request;
        }
    }
}
