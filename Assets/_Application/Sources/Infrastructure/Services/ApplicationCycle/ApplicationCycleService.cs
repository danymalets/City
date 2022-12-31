using System;
using UnityEngine;

namespace Sources.Infrastructure.Services.ApplicationCycle
{
    public class ApplicationCycleService : MonoBehaviour, IApplicationCycleService
    {
        public event Action BackButtonClicked = delegate { };
        public event Action<bool> FocusStatusChanged = delegate { };
        public event Action<bool> PauseStatusChanged = delegate { };
        public event Action ApplicationQuit = delegate { };
        
        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Escape))
                BackButtonClicked();
        }

        private void OnApplicationFocus(bool hasFocus) =>
            FocusStatusChanged(hasFocus);

        private void OnApplicationPause(bool pauseStatus) =>
            PauseStatusChanged(pauseStatus);

        private void OnApplicationQuit() =>
            ApplicationQuit();
    }
}