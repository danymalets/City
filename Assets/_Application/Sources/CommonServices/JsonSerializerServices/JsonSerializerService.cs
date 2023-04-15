using Newtonsoft.Json;

namespace _Application.Sources.CommonServices.JsonSerializerServices
{
    public class JsonSerializerService : IJsonSerializerService
    {
        public string Serialize<T>(T obj, bool isPretty = false) =>
            JsonConvert.SerializeObject(obj, isPretty ? Formatting.Indented : Formatting.None);

        public bool TryDeserialize<T>(string json, out T obj)
        {
            try
            {
                obj = JsonConvert.DeserializeObject<T>(json);
                return true;
            }
            catch
            {
                obj = default;
                return false;
            }
        }
    }
}