using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Base.Views;

namespace Sources.App.Ui.Screens.Debug_TODO
{
    public class DebugMenuScreenController : ScreenController
    {
        public DebugMenuScreenController(GameScreen gameScreen) : 
            base(gameScreen, new ToggleAnimator(gameScreen), true)
        {
            
        }

        protected override void OnRefresh()
        {
            
        }

        protected override void OnOpen()
        {
        }

        protected override void OnClose()
        {
        }
    }
}