using System;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Screens.LevelScreens.CarInputScreens;
using Sources.App.Ui.Screens.LevelScreens.PlayerInputScreens;

namespace Sources.App.Ui.Screens.LevelScreens
{
    public class LevelScreenController : ScreenController
    {
        private readonly LevelScreen _levelScreen;

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
        }

        protected override void OnRefresh()
        {
        }

        protected override void OnOpen()
        {
            _levelScreen.RestartButton.onClick.AddListener(OnRestartButtonClicked);
            _levelScreen.ExitButton.onClick.AddListener(OnExitButtonClicked);

            CarInputViewController.OnOpen();
            PlayerInputViewController.OnOpen();
        }

        protected override void OnClose()
        {
            _levelScreen.RestartButton.onClick.RemoveListener(OnRestartButtonClicked);
            _levelScreen.ExitButton.onClick.RemoveListener(OnExitButtonClicked);
            
            CarInputViewController.OnClose();
            PlayerInputViewController.OnClose();
        }

        private void OnRestartButtonClicked()
        {
            RestartButtonClicked();
        }

        private void OnExitButtonClicked()
        {
            ExitButtonClicked?.Invoke();
        }
    }
}