using Sources.Infrastructure.Services;

namespace Sources.UI.System
{
    public interface IUiCloseService : IService
    {
        void CloseAll();
    }
}