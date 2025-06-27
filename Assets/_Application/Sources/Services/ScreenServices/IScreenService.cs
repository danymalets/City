using System;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.ScreenServices
{
    public interface IScreenService : IService
    {
        int Height { get; }
        int Width { get; }
        Rect SafeArea { get; }
        float MaxDeviceFrameRate { get; }
        int SleepTimeout { get; set; }

        event Action ScreenResolutionChanged;
    }
}