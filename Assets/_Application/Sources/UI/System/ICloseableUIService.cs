using Sources.Infrastructure.Services;

namespace Sources.UI.System
{
    public interface ICloseableUIService : IService
    {
        void CloseAll();
    }
}