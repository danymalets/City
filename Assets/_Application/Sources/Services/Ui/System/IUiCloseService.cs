using Sources.Services.Di;

namespace Sources.Services.Ui.System
{
    public interface IUiCloseService : IService
    {
        void CloseAll();
    }
}