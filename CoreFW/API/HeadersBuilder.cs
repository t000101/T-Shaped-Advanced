using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;

namespace CoreFW.API
{
    public class HeadersBuilder
    {
        private HttpRequestMessage request;

        public HeadersBuilder()
        {
            this.request = new HttpRequestMessage();
        }

        public HeadersBuilder AddParam(string key, string value)
        {
            this.request.Headers.Add(key, value);
            return this;
        }

        public HttpRequestHeaders Build()
        {
            return this.request.Headers;
        }
    }
}
