namespace Sources.Services.UiServices.WindowBase.Screens
{
    public abstract class GameScreen : ScreenBase, IWindow
    {
        public Window Open()
        {
            OpenInternal();
            OnOpen();
            return this;
        }

        protected virtual void OnOpen()
        {
        }
    }
    
    public abstract class GameScreen<TPayload> : ScreenBase, IWindow<TPayload>
    {
        public Window Open(TPayload payload)
        {
            OpenInternal();
            OnOpen(payload);
            return this;
        }

        protected abstract void OnOpen(TPayload payload);
    }
}