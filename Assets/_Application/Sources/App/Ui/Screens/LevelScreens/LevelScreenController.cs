using System;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using UnityEngine;

namespace Sources.App.Ui.Screens.LevelScreens
{
    public class LevelScreenController : ScreenController
    {
        private readonly LevelScreen _levelScreen;
        
        public event Action RestartButtonClicked;
        public event Action ExitButtonClicked;

        public LevelScreenController(LevelScreen levelScreen) 
            : base(levelScreen, new ToggleAnimator(levelScreen))
        {
            _levelScreen = levelScreen;
        }
        
        protected override void OnOpen()
        {
            _levelScreen.RestartButton.onClick.AddListener(OnRestartButtonClicked);
            _levelScreen.ExitButton.onClick.AddListener(OnExitButtonClicked);
        }

        protected override void OnClose()
        {
            _levelScreen.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _levelScreen.ExitButton.onClick.RemoveListener(OnExitButtonClicked);
        }

        protected override void OnRefresh()
        {
        }

        private void OnRestartButtonClicked()
        {
            RestartButtonClicked();
        }

        private void OnExitButtonClicked()
        {
            Debug.Log($"exit");
            ExitButtonClicked?.Invoke();
        }
    }
}