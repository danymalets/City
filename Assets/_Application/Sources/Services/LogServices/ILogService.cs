using Sources.Utils.Di;

namespace Sources.Services.LogServices
{
    public interface ILogService : IService
    {
        void Log(string message);
        void LogWarning(string message);
        void LogError(string message);
        void LogException(System.Exception exception);
        bool IsLogEnabled { get; set; }
    }
} 