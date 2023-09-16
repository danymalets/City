using Sources.App.Ui.Controllers.Animators;
using Sources.Services.UiServices.WindowBase.Screens;

namespace Sources.App.Ui.Controllers
{
    public abstract class ScreenController<TPayload> : ScreenControllerBase
    {
        protected ScreenController(GameScreen gameScreen, ScreenAnimator animator) 
            : base(gameScreen, animator)
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
        protected ScreenController(GameScreen gameScreen, ScreenAnimator animator) 
            : base(gameScreen, animator)
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