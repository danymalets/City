using Sources.Utils.Di;

namespace Sources.Services.LogServices
{
    public interface ILogger
    {
        void Log(string message);
        void LogWarning(string message);
        void LogError(string message);
    }
} 