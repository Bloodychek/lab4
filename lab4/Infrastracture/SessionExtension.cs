using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lab4.Infrastracture
{
    public static class SessionExtension
    {
        public static void Set<T>(this ISession session, string Key, T value)
        {
            session.SetString(Key, JsonConvert.SerializeObject(value));
        }

        public static T Get<T>(this ISession session, string Key)
        {
            var value = session.GetString(Key);
            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
}
