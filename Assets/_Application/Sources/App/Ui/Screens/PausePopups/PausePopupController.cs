using System;
using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Base.Views;
using Sources.App.Ui.Screens.SettingsScreens;
using Sources.Services.TimeServices;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils;

namespace Sources.App.Ui.Screens.PausePopups
{
    public class PausePopupController : ScreenController
    {
        private readonly PausePopup _pausePopup;
        private DWorld _dWorld;
        private SettingsPopupController _settingsPopupController;
        private readonly ITimeService _timeService;

        public event Action RestartButtonClicked;
        public event Action ExitButtonClicked;
        
        public PausePopupController(PausePopup pausePopup) 
            : base(pausePopup, new FadeAnimator(pausePopup))
        {
            _pausePopup = pausePopup;
            _timeService = DiContainer.Resolve<ITimeService>();

        }

        protected override void OnCreate()
        {
            _settingsPopupController = DiContainer.Resolve<IUiControllersService>().Get<SettingsPopupController>();
        }

        protected override void OnOpen()
        {
            _dWorld = DiContainer.Resolve<DWorld>();
            _timeService.TimeScale = 0;
            _dWorld.IsPaused = true;
            _pausePopup.RestartButton.Button.onClick.AddListener(OnRestartButtonClicked);
            _pausePopup.ContinueButton.Button.onClick.AddListener(OnContinueButtonClicked);
            _pausePopup.ExitButton.Button.onClick.AddListener(OnExitButtonClicked);
            _pausePopup.SettingsButton.Button.onClick.AddListener(OnSettingsButtonClicked);
        }

        protected override void OnClose()
        {
            _dWorld.IsPaused = false;
            _timeService.TimeScale = 1;

            _dWorld = null;
            
            _pausePopup.RestartButton.Button.onClick.RemoveListener(OnRestartButtonClicked);
            _pausePopup.ContinueButton.Button.onClick.RemoveListener(OnContinueButtonClicked);
            _pausePopup.ExitButton.Button.onClick.RemoveListener(OnExitButtonClicked);
            _pausePopup.SettingsButton.Button.onClick.RemoveListener(OnSettingsButtonClicked);
        }

        protected override void OnRefresh()
        {
            _pausePopup.Title.text = "Title";
            _pausePopup.SettingsButton.Text.text = "Settings";
            _pausePopup.RestartButton.Text.text = "Restart";
            _pausePopup.ContinueButton.Text.text = "Continue";
            _pausePopup.ExitButton.Text.text = "Exit";
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
            _settingsPopupController.Open();
        }

        private void OnContinueButtonClicked()
        {
            Close();
        }
    }
}