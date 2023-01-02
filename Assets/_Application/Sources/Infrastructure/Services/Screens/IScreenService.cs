using System;
using UnityEngine;

namespace Sources.Infrastructure.Services.Screens
{
    public interface IScreenService : IService
    {
        int Height { get; }
        int Width { get; }
        Rect SafeArea { get; }
        int MaxDeviceFrameRate { get; }

        event Action ScreenResolutionChanged;
    }
}