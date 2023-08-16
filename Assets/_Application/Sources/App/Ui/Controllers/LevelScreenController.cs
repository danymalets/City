using System;
using Sources.App.Ui.Screens.Level;

namespace Sources.App.Ui.Controllers
{
    public class LevelScreenController : ScreenController<int>
    {
        private readonly LevelScreen _levelScreen;
        
        public event Action RestartButtonClicked;
        public event Action ExitButtonClicked;

        public LevelScreenController(LevelScreen levelScreen) 
            : base(levelScreen, new ToogleAnimator(levelScreen))
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

        protected override void OnRefresh()
        {
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