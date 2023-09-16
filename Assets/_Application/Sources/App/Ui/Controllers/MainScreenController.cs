using System;
using Sources.App.Ui.Controllers.Animators;
using Sources.App.Ui.Screens.Level;

namespace Sources.App.Ui.Controllers
{
    public class MainScreenController : ScreenController
    {
        private readonly MainScreen _mainScreen;
        
        public event Action PlayClicked = delegate { };

        public MainScreenController(MainScreen mainScreen) :
            base(mainScreen, new ToggleAnimator(mainScreen))
        {
            _mainScreen = mainScreen;
        }

        protected override void OnOpen()
        {
            _mainScreen.PlayButton.onClick.AddListener(OnPlayButtonClicked);
        }

        protected override void OnClose()
        {
            _mainScreen.PlayButton.onClick.RemoveListener(OnPlayButtonClicked);
        }

        protected override void OnRefresh()
        {
            _mainScreen.PlayButtonText.text = "Play";
        }

        private void OnPlayButtonClicked()
        {
            PlayClicked();
        }
    }
}