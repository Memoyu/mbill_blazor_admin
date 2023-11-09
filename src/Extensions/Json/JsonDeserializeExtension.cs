using Newtonsoft.Json;

namespace Mbill.Admin.Extensions.Json
{
    public static class JsonDeserializeExtension
    {
        public static T Deserialize<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
