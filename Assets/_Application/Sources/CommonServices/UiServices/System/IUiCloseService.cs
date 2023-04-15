using Sources.Utils.Di;

namespace Sources.CommonServices.UiServices.System
{
    public interface IUiCloseService : IService
    {
        void CloseAll();
    }
}