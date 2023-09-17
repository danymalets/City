using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;

namespace Sources.App.Ui.Screens.LoadingScreens
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
            SetProgress(0);
        }

        protected override void OnClose()
        {
        }

        protected override void OnRefresh()
        {
        }

        public void SetProgress(float value)
        {
            _loadingScreen.ProgressSlider.value = value;
        }
    }
}