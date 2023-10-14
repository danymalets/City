using Sources.Utils.Di;

namespace Sources.App.Ui.Base
{
    public interface IUiCloseService : IService
    {
        void CloseAll();
    }
}