namespace Sources.CommonServices.UiServices.WindowBase.Popups
{
    public abstract class Popup : PopupBase, IWindow
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
    
    public abstract class Popup<TPayload> : PopupBase, IWindow<TPayload>
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