using _Application.Sources.Utils.Di;

namespace _Application.Sources.CommonServices.UiServices.System
{
    public interface IUiCloseService : IService
    {
        void CloseAll();
    }
}