using Sources.Services.UiServices.WindowBase.Screens;
using Sources.Utils.Di;

namespace Sources.Services.UiServices.System
{
    public interface IUiViewsService : IService
    {
        TWindow Get<TWindow>() where TWindow : GameScreen;
    }
}