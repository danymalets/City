using System;

namespace Sources.App.Services.GameReloadServices
{
    public class GameReloadService : IGameReloadService
    {
        public event Action ReloadGameRequested;
        
        public void ReloadGame()
        {
            ReloadGameRequested?.Invoke();
        }
    }
}