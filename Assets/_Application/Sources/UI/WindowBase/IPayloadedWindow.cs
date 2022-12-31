namespace Sources.UI.WindowBase
{
    public interface IPayloadedWindow<TPayload> : IWindow
    {
        void Open(TPayload payload);
    }
}