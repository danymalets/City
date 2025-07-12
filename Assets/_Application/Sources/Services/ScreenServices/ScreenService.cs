using System;
using System.Linq;
using Sources.Services.UpdateLoopServices;
using Sources.Utils.CommonUtils.Utils;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.ScreenServices
{
    public class ScreenService : IInitializable, IScreenService
    {
        private readonly IUpdateLoopService _updateLoopService;
        public int Height { get; private set; }

        public int Width { get; private set; }
        public Vector2Int Size => new(Width, Height);

        public Rect SafeArea { get; private set; }

        public float MaxDeviceFrameRate => (float)Screen.resolutions.Max(r => r.refreshRateRatio.value);
        
        public int SleepTimeout
        {
            get => Screen.sleepTimeout;
            set => Screen.sleepTimeout = value;
        }

        public (Vector2 minAnchor, Vector2 maxAnchor) GetSafeAreaMinMaxAnchors()
        {
            Vector2 anchorMin = SafeArea.position;
            Vector2 anchorMax = SafeArea.position + SafeArea.size;

            anchorMin /= Size;
            anchorMax /= Size;
            return (anchorMin, anchorMax);
        }
        
        public event Action ScreenResolutionChanged;

        public ScreenService()
        {
            _updateLoopService = DiContainer.Resolve<IUpdateLoopService>();
        }

        public void Initialize()
        {
            UpdateResolution();
            
            _updateLoopService.RunEachSeconds(0.5f, () =>
            {
                if (Width != Screen.width ||
                    Height != Screen.height ||
                    MathUtils.NotEquals(SafeArea, Screen.safeArea))
                {
                    UpdateResolution();
                    ScreenResolutionChanged?.Invoke();
                }
            });
        }

        private void UpdateResolution()
        {
            Width = Screen.width;
            Height = Screen.height;
            SafeArea = Screen.safeArea;
        }
    }
}