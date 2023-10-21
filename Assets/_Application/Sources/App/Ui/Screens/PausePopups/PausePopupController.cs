using System;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Base.Views;

namespace Sources.App.Ui.Screens.PausePopups
{
    public class PausePopupController : ScreenController
    {
        private readonly PausePopup _pausePopup;
        
        public event Action RestartButtonClicked;
        public event Action ExitButtonClicked;
        
        public PausePopupController(PausePopup pausePopup) 
            : base(pausePopup, new DefaultPopupAnimator(pausePopup))
        {
            _pausePopup = pausePopup;
        }

        protected override void OnRefresh()
        {
            _pausePopup.RestartButton.Text.text = "a";
            _pausePopup.ExitButton.Text.text = "b";
            _pausePopup.SettingsButton.Text.text = "b";
        }

        protected override void OnOpen()
        {
            _pausePopup.RestartButton.Button.onClick.AddListener(OnRestartButtonClicked);
            _pausePopup.ExitButton.Button.onClick.AddListener(OnExitButtonClicked);
            _pausePopup.SettingsButton.Button.onClick.AddListener(OnSettingsButtonClicked);
        }

        protected override void OnClose()
        {
            _pausePopup.RestartButton.Button.onClick.RemoveListener(OnRestartButtonClicked);
            _pausePopup.ExitButton.Button.onClick.RemoveListener(OnExitButtonClicked);
            _pausePopup.SettingsButton.Button.onClick.RemoveListener(OnSettingsButtonClicked);
        }

        private void OnRestartButtonClicked()
        {
            RestartButtonClicked?.Invoke();
        }

        private void OnExitButtonClicked()
        {
            ExitButtonClicked?.Invoke();
        }

        private void OnSettingsButtonClicked()
        {
            
        }
    }
}