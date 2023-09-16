using Sources.App.Ui.Controllers;
using Sources.App.Ui.Controllers.Animators;
using Sources.App.Ui.Screens;
using Sources.Services.UiServices.WindowBase.Screens;

namespace Sources.App.Ui.ToMove.LoadingScreens
{
    public class LoadingScreenController : ScreenController
    {
        private readonly LoadingScreen _loadingScreen;

        public LoadingScreenController(LoadingScreen loadingScreen) 
            : base(loadingScreen, new ToggleAnimator(loadingScreen))
        {
            _loadingScreen = loadingScreen;
        }

        protected override void OnOpen()
        {
        }

        protected override void OnClose()
        {
        }

        protected override void OnRefresh()
        {
        }

        public void SetProgress(float value)
        {
            _loadingScreen.SetProgress(value);
        }
    }
}