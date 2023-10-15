using System;
using Sources.App.Services.AudioServices;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Screens.LevelScreens.CarInputScreens;
using Sources.App.Ui.Screens.LevelScreens.PlayerInputScreens;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.LevelScreens
{
    public class LevelScreenController : ScreenController
    {
        private readonly LevelScreen _levelScreen;
        private readonly IAudioService _audioService;

        public CarInputViewController CarInputViewController { get; private set; }
        public PlayerInputViewController PlayerInputViewController { get; private set; }
        
        public event Action RestartButtonClicked;
        public event Action ExitButtonClicked;


        public LevelScreenController(LevelScreen levelScreen) 
            : base(levelScreen, new ToggleAnimator(levelScreen))
        {
            _levelScreen = levelScreen;
            CarInputViewController = new CarInputViewController(_levelScreen.CarInputView);
            PlayerInputViewController = new PlayerInputViewController(_levelScreen.PlayerInputView);
            _audioService = DiContainer.Resolve<IAudioService>();
        }

        protected override void OnRefresh()
        {
        }

        protected override void OnOpen()
        {
            _levelScreen.RestartButton.onClick.AddListener(OnRestartButtonClicked);
            _levelScreen.ExitButton.onClick.AddListener(OnExitButtonClicked);
            _levelScreen.PauseButton.onClick.AddListener(OnPauseButtonClicked);

            CarInputViewController.OnOpen();
            PlayerInputViewController.OnOpen();
        }

        protected override void OnClose()
        {
            _levelScreen.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _levelScreen.ExitButton.onClick.RemoveListener(OnExitButtonClicked);
            _levelScreen.PauseButton.onClick.RemoveListener(OnPauseButtonClicked);
            
            CarInputViewController.OnClose();
            PlayerInputViewController.OnClose();
        }

        private void OnRestartButtonClicked()
        {
            RestartButtonClicked?.Invoke();
        }

        private void OnExitButtonClicked()
        {
            ExitButtonClicked?.Invoke();
        }

        private void OnPauseButtonClicked()
        {
            _audioService.PlayOnce(SoundEffectType.ButtonClick);
        }
    }
}