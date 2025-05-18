using System;
using System.Globalization;
using UnityEngine;

namespace Sources.Services.LogServices
{
    public class Logger<T> : ILogger
    {
        private readonly float _deltaHour;
    
        public Logger(LogSettings logSettings)
        {
            _deltaHour = logSettings.IsLocalTime ? (float)(DateTime.Now - DateTime.UtcNow).TotalHours : 0f;
        }
    
        public void Log(string message) => Debug.Log(GetLogText(message));
        public void LogWarning(string message) => Debug.LogWarning($"[**WARNING**] {GetLogText(message)}");
        public void LogError(string message) => Debug.LogWarning($"[****ERROR****] {GetLogText(message)}");

        private string GetLogText(string message) => 
            $"[{DateTime.UtcNow.AddHours(_deltaHour).ToString(@"MM\/dd\/yyyy HH:mm:ss.fff",CultureInfo.InvariantCulture)} UTC+{_deltaHour}] <{typeof(T).Name}> {message}";
    }
}