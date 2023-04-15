using _Application.Sources.Utils.Di;

namespace _Application.Sources.CommonServices.JsonSerializerServices
{
    public interface IJsonSerializerService : IService
    {
        string Serialize<T>(T obj, bool isPretty = false);
        bool TryDeserialize<T>(string json, out T obj);
    }
}