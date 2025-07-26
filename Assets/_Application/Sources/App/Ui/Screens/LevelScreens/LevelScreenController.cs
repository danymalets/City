using System;
using Sources.App.Services.AssetsServices.Audio;
using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Screens.LevelScreens.PlayerInputScreens;
using Sources.App.Ui.Screens.PausePopups;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.LevelScreens
{
    public class LevelScreenController : ScreenController
    {
        private readonly LevelScreen _levelScreen;
        private PausePopupController _pausePopupController;

        public PlayerInputViewController PlayerInputViewController { get; private set; }

        public LevelScreenController(LevelScreen levelScreen) 
            : base(levelScreen, new ToggleAnimator(levelScreen))
        {
            PlayerInputViewController = new PlayerInputViewController(levelScreen.PlayerInputView);
            _levelScreen = levelScreen;
        }

        protected override void OnCreate()
        {
            _pausePopupController = DiContainer.Resolve<IUiControllersService>().Get<PausePopupController>();
        }

        protected override void OnOpen()
        {
            _levelScreen.PauseButton.onClick.AddListener(OnPauseButtonClicked);
            
            PlayerInputViewController.OnOpen();
        }

        protected override void OnClose()
        {
            _levelScreen.PauseButton.onClick.RemoveListener(OnPauseButtonClicked);
            
            PlayerInputViewController.OnClose();
        }
        
        private void OnPauseButtonClicked()
        {
            _audioService.PlayOnce(SoundType.ButtonClick);
            _pausePopupController.Open();
        }
    }
}