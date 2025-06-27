using System;
using System.Linq;
using Sources.Services.GameLoopServices;
using Sources.Utils.CommonUtils.Utils;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.ScreenServices
{
    public class ScreenService : IInitializable, IScreenService
    {
        private readonly IGameLoopService _gameLoopService;
        public int Height { get; private set; }

        public int Width { get; private set; }

        public Rect SafeArea { get; private set; }

        public float MaxDeviceFrameRate => (float)Screen.resolutions.Max(r => r.refreshRateRatio.value);
        
        public int SleepTimeout
        {
            get => Screen.sleepTimeout;
            set => Screen.sleepTimeout = value;
        }

        public event Action ScreenResolutionChanged;

        public ScreenService()
        {
            _gameLoopService = DiContainer.Resolve<IGameLoopService>();
        }

        public void Initialize()
        {
            UpdateResolution();
            
            _gameLoopService.RunEachSeconds(0.5f, () =>
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