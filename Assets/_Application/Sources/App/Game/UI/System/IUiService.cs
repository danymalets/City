using Sources.App.Game.UI.WindowBase;
using Sources.App.Infrastructure.Services;

namespace Sources.App.Game.UI.System
{
    public interface IUiService : IService
    {
        TWindow Get<TWindow>() where TWindow : Window;
        Window Open<TWindow>() where TWindow : Window, IWindow;
    }
}