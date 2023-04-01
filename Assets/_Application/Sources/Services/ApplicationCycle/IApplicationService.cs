using System;
using Sources.Services.Di;

namespace Sources.Services.ApplicationCycle
{
    public interface IApplicationService : IService
    {
        event Action BackButtonClicked;
        event Action<bool> FocusStatusChanged;
        event Action<bool> PauseStatusChanged;
        event Action ApplicationQuit;
        int TargetFrameRate { get; set; }
        string DeviceName { get; }
        string DeviceModel { get; }
    }
}