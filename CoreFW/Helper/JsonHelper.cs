using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace CoreFW.Helper
{
    public class JsonHelper
    {
        public static string GetValue(string json, string key)
        {
            JObject parent = JObject.Parse(json);
            JObject valueObj;
            try
            {
                valueObj = parent.Value<JObject>(key);
            } catch (InvalidCastException)
            {
                try
                {
                    return parent.Value<string>(key);
                }
                catch (InvalidCastException)
                {
                    return parent.Value<JArray>(key).ToString();
                }
                
            }

            return valueObj.ToString();
        }

        public static string GetJsonContentFromResponse(HttpResponseMessage response)
        {
            string json;
            using (HttpContent content = response.Content)
            {
                json = content.ReadAsStringAsync().Result;
            }
            return json;
        }
    }
}
