using System;
using Sources.Services.ApplicationInputServices;
using Sources.Services.CoroutineRunnerServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.ApplicationServices
{
    public class ApplicationService : MonoBehaviour, IApplicationService, IInitializable
    {
        public event Action BackButtonClicked;
        public event Action<bool> FocusStatusChanged;
        public event Action Focused;
        public event Action Unfocused;
        public event Action<bool> PauseStatusChanged;
        public event Action Paused;
        public event Action Unpaused;
        public event Action ApplicationQuit;

        private CoroutineContext _coroutineContext;
        private IApplicationInputService _applicationInput;

        public int TargetFrameRate
        {
            get => Application.targetFrameRate;
            set => Application.targetFrameRate = value;
        }

        public string DeviceName =>
            SystemInfo.deviceName;

        public RuntimePlatform ApplicationPlatform => Application.platform;

        public string DeviceModel =>
            SystemInfo.deviceModel;

        public bool HasInternet => Application.internetReachability != NetworkReachability.NotReachable;
        public SystemLanguage SystemLanguage => Application.systemLanguage;

        public void Initialize()
        {
            _coroutineContext = new CoroutineContext();

            _applicationInput = DiContainer.Resolve<IApplicationInputService>();
            
            _coroutineContext.RunEachFrame(() =>
            {
                if (_applicationInput.GetKeyDown(KeyCode.Escape))
                    BackButtonClicked?.Invoke();
            }, true);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            FocusStatusChanged?.Invoke(hasFocus);
            Debug.Log($"hasFocus {hasFocus}");
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            PauseStatusChanged?.Invoke(pauseStatus);
            Debug.Log($"pauseStatus {pauseStatus}");
        }

        private void OnApplicationQuit() =>
            ApplicationQuit?.Invoke();
    }
}