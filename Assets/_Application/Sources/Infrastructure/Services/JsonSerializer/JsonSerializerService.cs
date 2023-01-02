using System;
using Newtonsoft.Json;

namespace Sources.Infrastructure.Services.JsonSerializer
{
    public class JsonSerializerService : IJsonSerializerService
    {
        public string Serialize<T>(T obj, bool isPretty = false) =>
            JsonConvert.SerializeObject(obj, isPretty ? Formatting.None : Formatting.Indented);

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