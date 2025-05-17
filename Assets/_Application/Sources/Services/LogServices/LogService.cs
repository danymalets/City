using System;
using UnityEngine;

namespace Sources.Services.LogServices
{
    public class LogService : ILogService
    {
        public bool IsLogEnabled { get; set; } = true;

        public void Log(string message)
        {
            if (!IsLogEnabled) return;
            Debug.Log(message);
        }

        public void LogWarning(string message)
        {
            if (!IsLogEnabled) return;
            Debug.LogWarning(message);
        }

        public void LogError(string message)
        {
            if (!IsLogEnabled) return;
            Debug.LogError(message);
        }

        public void LogException(Exception exception)
        {
            if (!IsLogEnabled) return;
            Debug.LogException(exception);
        }
    }
} 