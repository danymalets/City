namespace Sources.App.Ui.Controllers
{
    public abstract class ScreenController<TPayload> : ScreenControllerBase
    {
        protected ScreenController(ScreenAnimator animator) : base(animator)
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
        public void Open()
        {
            OnOpenInternal();
            OnOpen();
        }

        protected abstract void OnOpen();

        protected ScreenController(ScreenAnimator animator) : base(animator)
        {
        }
    }
}