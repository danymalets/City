using Sources.Services.Di;

namespace Sources.Services.Ui.System
{
    public interface IUiRefreshService : IService
    {
        void Refresh();
    }
}