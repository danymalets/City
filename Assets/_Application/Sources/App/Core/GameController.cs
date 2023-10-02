using System;
using Sources.App.Core.Ecs;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.App.Services.AudioServices;
using Sources.App.Services.UserServices;
using Sources.Services.AnalyticsServices;
using Sources.Services.FpsServices;
using Sources.Services.UiServices.System;
using Sources.Utils.Di;

namespace Sources.App.Core
{
    public class GameController
    {
        private readonly IAudioService _audio;
        private readonly IUiCloseService _uiClose;
        private readonly IDiBuilder _diBuilder;
        private readonly IAnalyticsService _analytics;
        private readonly GameLoader _gameLoader;

        private Game _game;
        
        public event Action ForceReloadRequested; 

        public GameController()
        {
            _analytics = DiContainer.Resolve<IAnalyticsService>();
            _audio = DiContainer.Resolve<IAudioService>();

            _diBuilder = DiBuilder.Create();
            
            _uiClose = DiContainer.Resolve<IUiCloseService>();
            
            _gameLoader = new GameLoader();
        }
        
        public void StartGame()
        {
            _gameLoader.StartLoadGame(levelContext =>
            {
                _diBuilder.Register(levelContext);
                
                _game = new Game();
                _game.StartGame();
            }, GameLoadingFinished, () =>
            {
                ForceReloadRequested?.Invoke();
            });
        }

        private void GameLoadingFinished()
        {
            _analytics.SendLevelStarted(1);
        }

        public void FinishGame()
        {
            _analytics.SendLevelFinished(1, 0);
            
            _game.FinishGame();
            _audio.StopAll();
            _uiClose.CloseAll();

            _diBuilder.Dispose();
        }
    }
}