using System;
using Sources.App.Services.AudioServices;
using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Screens.LevelScreens.CarInputScreens;
using Sources.App.Ui.Screens.LevelScreens.PlayerInputScreens;
using Sources.App.Ui.Screens.PausePopups;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.LevelScreens
{
    public class LevelScreenController : ScreenController
    {
        private readonly LevelScreen _levelScreen;
        private readonly IAudioService _audioService;
        private PausePopupController _pausePopupController;

        public CarInputViewController CarInputViewController { get; private set; }
        public PlayerInputViewController PlayerInputViewController { get; private set; }

        public LevelScreenController(LevelScreen levelScreen) 
            : base(levelScreen, new ToggleAnimator(levelScreen))
        {
            CarInputViewController = new CarInputViewController(levelScreen.CarInputView);
            PlayerInputViewController = new PlayerInputViewController(levelScreen.PlayerInputView);
            _audioService = DiContainer.Resolve<IAudioService>();
            _levelScreen = levelScreen;
        }

        protected override void OnCreate()
        {
            _pausePopupController = DiContainer.Resolve<IUiControllersService>().Get<PausePopupController>();
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

        protected override void OnRefresh()
        {
            
        }

        private void OnPauseButtonClicked()
        {
            _pausePopupController.Open();
        }
    }
}