using System;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.ScreenServices
{
    public interface IScreenService : IService
    {
        int Height { get; }
        int Width { get; }
        public Vector2Int Size { get; }
        Rect SafeArea { get; }
        float MaxDeviceFrameRate { get; }
        int SleepTimeout { get; set; }
        (Vector2 minAnchor, Vector2 maxAnchor) GetSafeAreaMinMaxAnchors();
        event Action ScreenResolutionChanged;
    }
}