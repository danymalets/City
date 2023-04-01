using Sources.Di;

namespace Sources.App.Game.UI.System
{
    public interface IUiCloseService : IService
    {
        void CloseAll();
    }
}