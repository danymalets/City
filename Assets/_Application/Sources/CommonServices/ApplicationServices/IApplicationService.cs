using System;
using _Application.Sources.Utils.Di;

namespace _Application.Sources.CommonServices.ApplicationServices
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