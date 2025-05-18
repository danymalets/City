using Sources.Utils.Di;

namespace Sources.Services.LogServices
{
    public interface ILogService : IService
    {
        ILogger CreateLogger<T>();
    }
}