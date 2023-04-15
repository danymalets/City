using System;
using _Application.Sources.Utils.Di;
using UnityEngine;

namespace _Application.Sources.CommonServices.ScreenServices
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