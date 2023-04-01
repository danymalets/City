using System;
using UnityEngine;

namespace Sources.App.Infrastructure.Services.Screens
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