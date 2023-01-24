using System;
using System.Linq;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Infrastructure.Services.Screens
{
    public class ScreenService : IInitializable, IScreenService
    {
        public int Height { get; private set; }

        public int Width { get; private set; }

        public Rect SafeArea { get; private set; }

        public int MaxDeviceFrameRate => Screen.resolutions.Max(r => r.refreshRate);

        public int SleepTimeout
        {
            get => Screen.sleepTimeout;
            set => Screen.sleepTimeout = value;
        }

        public event Action ScreenResolutionChanged;

        private CoroutineContext _coroutineContext;

        public void Initialize()
        {
            UpdateResolution();

            _coroutineContext = new CoroutineContext();

            _coroutineContext.RunEachSeconds(0.5f, () =>
            {
                if (Width != Screen.width ||
                    Height != Screen.height ||
                    DMath.NotEquals(SafeArea, Screen.safeArea))
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