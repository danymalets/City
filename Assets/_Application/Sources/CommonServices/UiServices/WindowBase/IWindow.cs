namespace Sources.CommonServices.UiServices.WindowBase
{
    public interface IWindow
    {
        Window Open();
    }
    
    public interface IWindow<TPayload> : IWindowBase
    {
        Window Open(TPayload payload);
    }
}