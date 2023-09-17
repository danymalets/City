using Sources.App.Ui.Base.Animators;
using Sources.Services.UiServices.WindowBase.Screens;

namespace Sources.App.Ui.Base
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

    public abstract class ScreenController : ScreenControllerBase
    {
        protected ScreenController(GameScreen gameScreen, ScreenAnimator animator, bool isAlwaysOpen = false) 
            : base(gameScreen, animator, isAlwaysOpen)
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