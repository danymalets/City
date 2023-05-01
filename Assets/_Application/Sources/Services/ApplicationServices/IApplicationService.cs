using System;
using Sources.Utils.Di;

namespace Sources.Services.ApplicationServices
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