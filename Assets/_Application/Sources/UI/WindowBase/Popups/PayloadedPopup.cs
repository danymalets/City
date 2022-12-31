namespace Sources.UI.WindowBase.Popups
{
    public abstract class PayloadedPopup<TPayload> : Popup, IPayloadedWindow<TPayload>
    {
        public void Open(TPayload payload)
        {
            OpenInternal();
            OnOpen(payload);
        }

        protected abstract void OnOpen(TPayload payload);
    }
}