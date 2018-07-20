using Newtonsoft.Json;

namespace GoIdentity.Utilities
{
    public static class SerializationHelper
    {
        public static string Serialize<T>(T value)
        {
            return JsonConvert.SerializeObject(value);
        }

        public static T Deserialize<T>(string value)
        {
            return JsonConvert.DeserializeObject<T>(value);
        }
    }
}
