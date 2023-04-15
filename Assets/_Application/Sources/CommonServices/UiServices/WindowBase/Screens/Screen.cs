namespace Sources.CommonServices.UiServices.WindowBase.Screens
{
    public abstract class Screen : ScreenBase, IWindow
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
    
    public abstract class Screen<TPayload> : ScreenBase, IWindow<TPayload>
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