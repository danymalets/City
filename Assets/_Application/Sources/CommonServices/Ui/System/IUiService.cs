using Sources.Services.Di;
using Sources.Services.Ui.WindowBase;

namespace Sources.Services.Ui.System
{
    public interface IUiService : IService
    {
        TWindow Get<TWindow>() where TWindow : Window;
        Window Open<TWindow>() where TWindow : Window, IWindow;
    }
}