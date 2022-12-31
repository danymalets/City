
namespace Sources.UI.WindowBase.Screens
{
    public abstract class PayloadedScreen<TPayload> : Screen, IPayloadedWindow<TPayload>
    {
        public void Open(TPayload payload)
        {
            OpenInternal();
            OnOpen(payload);
        }

        protected abstract void OnOpen(TPayload payload);
    }
}