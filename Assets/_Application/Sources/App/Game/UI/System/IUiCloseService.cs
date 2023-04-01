using Sources.App.Infrastructure.Services;

namespace Sources.App.Game.UI.System
{
    public interface IUiCloseService : IService
    {
        void CloseAll();
    }
}