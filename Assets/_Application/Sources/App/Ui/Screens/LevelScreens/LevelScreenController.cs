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
            _levelScreen.PauseButton.onClick.AddListener(OnPauseButtonClicked);
            
            CarInputViewController.OnOpen();
            PlayerInputViewController.OnOpen();
        }

        protected override void OnClose()
        {
            _levelScreen.PauseButton.onClick.RemoveListener(OnPauseButtonClicked);
            
            CarInputViewController.OnClose();
            PlayerInputViewController.OnClose();
        }

        

        private void OnPauseButtonClicked()
        {
            _audioService.PlayOnce(SoundEffectType.ButtonClick);
        }
    }
}