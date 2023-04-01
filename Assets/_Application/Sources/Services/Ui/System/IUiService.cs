using Sources.App.Game.UI.WindowBase;
using Sources.Di;

namespace Sources.App.Game.UI.System
{
    public interface IUiService : IService
    {
        TWindow Get<TWindow>() where TWindow : Window;
        Window Open<TWindow>() where TWindow : Window, IWindow;
    }
}