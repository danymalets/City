using Sources.App.Infrastructure.Services;

namespace Sources.App.Game.UI.System
{
    public interface IUiRefreshService : IService
    {
        void Refresh();
    }
}