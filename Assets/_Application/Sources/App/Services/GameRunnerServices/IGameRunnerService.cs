using Sources.Utils.Di;

namespace Sources.App.Services.GameRunnerServices
{
    public interface IGameRunnerService : IService
    {
        public void RunGame(RunGameSettings runGameSettings);
    }
}