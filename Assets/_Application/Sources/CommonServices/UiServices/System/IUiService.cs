using Sources.CommonServices.UiServices.WindowBase;
using Sources.Utils.Di;

namespace Sources.CommonServices.UiServices.System
{
    public interface IUiService : IService
    {
        TWindow Get<TWindow>() where TWindow : Window;
        Window Open<TWindow>() where TWindow : Window, IWindow;
    }
}