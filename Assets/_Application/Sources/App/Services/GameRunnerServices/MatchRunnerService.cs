using System;

namespace Sources.App.Services.GameRunnerServices
{
    public class MatchRunnerService : IGameRunnerService
    {
        public event Action<RunMatchSettings> RunGameRequested;
        
        public void RunGame(RunMatchSettings runMatchSettings)
        {
            RunGameRequested?.Invoke(runMatchSettings);
        }
    }
}