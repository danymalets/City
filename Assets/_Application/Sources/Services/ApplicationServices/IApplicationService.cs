using System;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.ApplicationServices
{
    public interface IApplicationService : IService
    {
        event Action BackButtonClicked;
        event Action<bool> FocusStatusChanged;
        event Action Focused;
        event Action Unfocused;
        event Action<bool> PauseStatusChanged;
        event Action Paused;
        event Action Unpaused;
        event Action ApplicationQuit;
        int TargetFrameRate { get; set; }
        string DeviceName { get; }
        RuntimePlatform ApplicationPlatform { get; }
        string DeviceModel { get; }
        bool HasInternet { get; }
        SystemLanguage SystemLanguage { get; }
        void OpenUrl(string url);
    }
}