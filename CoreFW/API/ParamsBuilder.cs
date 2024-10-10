using System.Collections.Generic;
using Newtonsoft.Json;

namespace CoreFW.API
{
    public class ParamsBuilder
    {
        private IDictionary<string, object> parameters;

        public ParamsBuilder() {
            this.parameters = new Dictionary<string, object>();
        }

        public ParamsBuilder AddParam(string key, object value)
        {
            this.parameters.Add(key, value);
            return this;
        }

        public string Build()
        {
            string query = "";
            foreach(string key in parameters.Keys)
            {
                query += $"{key}={parameters[key]}&";
            }

            query = query.Substring(0, query.Length - 1);
            return query;
        }
    }
}
