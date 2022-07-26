using Newtonsoft.Json;

namespace mbill_blazor_admin.Extensions.Json
{
    public static class JsonDeserializeExtension
    {
        public static T Deserialize<T>(this string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
