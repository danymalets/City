using Sources.Utils.Di;

namespace Sources.Services.UiServices.System
{
    public interface IUiCloseService : IService
    {
        void CloseAll();
    }
}