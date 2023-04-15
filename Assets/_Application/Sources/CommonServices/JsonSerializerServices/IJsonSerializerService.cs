using Sources.Utils.Di;

namespace Sources.CommonServices.JsonSerializerServices
{
    public interface IJsonSerializerService : IService
    {
        string Serialize<T>(T obj, bool isPretty = false);
        bool TryDeserialize<T>(string json, out T obj);
    }
}