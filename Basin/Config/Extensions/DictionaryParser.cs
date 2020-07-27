using System;
using System.Collections.Generic;
using Config.Net;
using Newtonsoft.Json;

namespace Basin.Config.Extensions
{
    public class DictionaryParser : ITypeParser
    {
        public IEnumerable<Type> SupportedTypes => new[] { typeof(Dictionary<string, object>) };

        public bool TryParse(string value, Type t, out object result)
        {
            if (value == null)
            {
                result = null;
                return false;
            }

            result = JsonConvert.DeserializeObject(value, t);

            return true;
        }

        public string ToRawString(object value)
        {
            if (value == null) return null;
            return JsonConvert.SerializeObject(value);
        }
    }
}