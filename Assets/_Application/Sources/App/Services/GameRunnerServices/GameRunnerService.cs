using System;

namespace Sources.App.Services.GameRunnerServices
{
    public class GameRunnerService : IGameRunnerService
    {
        public event Action<RunGameSettings> RunGameRequested;
        
        public void RunGame(RunGameSettings runGameSettings)
        {
            RunGameRequested?.Invoke(runGameSettings);
        }
    }
}