using Sources.Utils.Di;

namespace Sources.App.Services.GameReloadServices
{
    public interface IGameReloadService : IService
    {
        public void ReloadGame();
    }
}