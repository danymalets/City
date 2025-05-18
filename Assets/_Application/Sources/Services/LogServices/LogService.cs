namespace Sources.Services.LogServices
{
    public class LogService : ILogService
    {
        private readonly LogSettings _logSettings;

        public LogService(LogSettings logSettings)
        {
            _logSettings = logSettings;
        }

        public ILogger CreateLogger<T>() => new Logger<T>(_logSettings);
    }
} 