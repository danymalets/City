using Sources.App.Ui.Controllers;
using Sources.App.Ui.Controllers.Animators;

namespace Sources.App.Ui.ToMove.MapScreens
{
    public class MapScreenController : ScreenController
    {
        private readonly MapScreen _mapScreen;

        public MapScreenController(MapScreen mapScreen)
            : base(mapScreen, new ToggleAnimator(mapScreen))
        {
            _mapScreen = mapScreen;
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
    }
}