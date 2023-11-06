using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Views;

namespace Sources.App.Ui.Base.Controllers
{
    public abstract class ScreenController : ScreenControllerBase
    {
        protected ScreenController(GameScreen gamePopup, ScreenAnimator animator, bool isAlwaysOpen = false) 
            : base(gamePopup, animator, isAlwaysOpen)
        {
        }

        public void Open()
        {
            OnOpenInternal();
            OnOpen();
        }

        protected abstract void OnOpen();
    }
}