using System;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.CommonServices.ScreenServices
{
    public interface IScreenService : IService
    {
        int Height { get; }
        int Width { get; }
        Rect SafeArea { get; }
        int MaxDeviceFrameRate { get; }
        int SleepTimeout { get; set; }

        event Action ScreenResolutionChanged;
    }
}