using System;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using UnityEngine;

namespace Sources.App.Ui.Screens.LevelScreens
{
    public class LevelScreenController : ScreenController<int>
    {
        private readonly LevelScreen _levelScreen;
        
        public event Action RestartButtonClicked;
        public event Action ExitButtonClicked;

        public LevelScreenController(LevelScreen levelScreen) 
            : base(levelScreen, new ToggleAnimator(levelScreen))
        {
            _levelScreen = levelScreen;
        }
        
        protected override void OnOpen(int level)
        {
            _levelScreen.RestartButton.onClick.AddListener(OnRestartButtonClicked);
            _levelScreen.ExitButton.onClick.AddListener(OnExitButtonClicked);
        }

        protected override void OnClose()
        {
            _levelScreen.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _levelScreen.ExitButton.onClick.RemoveListener(OnExitButtonClicked);
        }

        protected override void OnRefresh(StringsAsset strings)
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