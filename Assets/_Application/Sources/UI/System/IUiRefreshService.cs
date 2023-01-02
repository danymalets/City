using Sources.Infrastructure.Services;

namespace Sources.UI.System
{
    public interface IUiRefreshService : IService
    {
        void Refresh();
    }
}