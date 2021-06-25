using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace mbill_blazor_admin.Extensions.Json
{
    public static class JsonDeserializeExtension
    {
        public static T Deserialize<T>(this string json)
        {
            return JsonSerializer.Deserialize<T>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
        }
    }
}
