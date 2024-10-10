using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoreFW.API
{
    public class JsonBuilder
    {
        private IDictionary<string, object> body;

        public JsonBuilder()
        {
            this.body = new Dictionary<string, object>();
        }

        public JsonBuilder AddParam(string key, object value)
        {
            this.body.Add(key, value);
            return this;
        }

        public string Build()
        {
            return JsonConvert.SerializeObject(this.body);
        }
    }
}
