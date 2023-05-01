using Sources.Services.UiServices.WindowBase;
using Sources.Utils.Di;

namespace Sources.Services.UiServices.System
{
    public interface IUiService : IService
    {
        TWindow Get<TWindow>() where TWindow : Window;
        Window Open<TWindow>() where TWindow : Window, IWindow;
    }
}