using _Application.Sources.CommonServices.UiServices.WindowBase;
using _Application.Sources.Utils.Di;

namespace _Application.Sources.CommonServices.UiServices.System
{
    public interface IUiService : IService
    {
        TWindow Get<TWindow>() where TWindow : Window;
        Window Open<TWindow>() where TWindow : Window, IWindow;
    }
}