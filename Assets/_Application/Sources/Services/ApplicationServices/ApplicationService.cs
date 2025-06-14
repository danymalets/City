using System;
using Sources.Services.ApplicationInputServices;
using Sources.Services.GameLoopServices;
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

        private IApplicationInputService _applicationInput;
        private IGameLoopService _gameLoopService;

        public int TargetFrameRate
        {
            get => Application.targetFrameRate;
            set => Application.targetFrameRate = value;
        }

        public string DeviceName =>
            SystemInfo.deviceName;

        public RuntimePlatform ApplicationPlatform => 
            Application.platform;

        public string DeviceModel =>
            SystemInfo.deviceModel;

        public bool IsInternetReachable => 
            Application.internetReachability != NetworkReachability.NotReachable;
        
        public SystemLanguage SystemLanguage =>
            Application.systemLanguage;
        
        public void OpenUrl(string url) =>
            Application.OpenURL(url);

        public void Initialize()
        {
            _applicationInput = DiContainer.Resolve<IApplicationInputService>();
            _gameLoopService = DiContainer.Resolve<IGameLoopService>();
            
            _gameLoopService.RunEachFrame(() =>
            {
                if (_applicationInput.GetKeyDown(KeyCode.Escape))
                    BackButtonClicked?.Invoke();
            }, true);
        }

        private void OnApplicationFocus(bool hasFocus)
        {
            if (hasFocus)
            {
                Focused?.Invoke();
            }
            else
            {
                Unfocused?.Invoke();
            }
            
            FocusStatusChanged?.Invoke(hasFocus);
        }

        private void OnApplicationPause(bool pauseStatus)
        {
            if (pauseStatus)
            {
                Paused?.Invoke();
            }
            else
            {
                Unpaused?.Invoke();
            }
            
            PauseStatusChanged?.Invoke(pauseStatus);
            
            Debug.Log($"pauseStatus {pauseStatus}");
        }

        private void OnApplicationQuit() =>
            ApplicationQuit?.Invoke();

        public void Quit() => 
            Application.Quit();
    }
}