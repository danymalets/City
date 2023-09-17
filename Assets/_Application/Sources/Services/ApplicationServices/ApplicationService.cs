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
        public event Action<bool> PauseStatusChanged;
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
        
        public string DeviceModel =>
            SystemInfo.deviceModel;

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

        private void OnApplicationFocus(bool hasFocus) =>
            FocusStatusChanged?.Invoke(hasFocus);

        private void OnApplicationPause(bool pauseStatus) =>
            PauseStatusChanged?.Invoke(pauseStatus);

        private void OnApplicationQuit() =>
            ApplicationQuit?.Invoke();

    }
}