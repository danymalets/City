using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Views;

namespace Sources.App.Ui.Base.Controllers
{
    public abstract class ScreenController<TPayload> : ScreenControllerBase
    {
        protected ScreenController(GameScreen gameScreen, ScreenAnimator animator, bool isAlwaysOpen = false) 
            : base(gameScreen, animator, isAlwaysOpen)
        {
        }

        public void Open(TPayload payload)
        {
            OnOpenInternal();
            OnOpen(payload);
        }

        protected abstract void OnOpen(TPayload payload);
    }
}