using Sources.App.Game.InputServices;
using Sources.App.Game.UI.Screens;
using Sources.App.Game.UI.Screens.Input;
using Sources.App.Game.UI.Screens.Level;
using Sources.App.Game.UI.System;
using Sources.App.Infrastructure.Bootstrap;
using Sources.Di;
using Sources.Services.Audio;
using Sources.Services.BalanceManager;
using Sources.Services.CoroutineRunner;
using Sources.Services.Fps;

namespace Sources.App.Game
{
    public class GameController
    {
        private readonly LevelScreen _levelScreen;
        private readonly CarInputScreen _carInputScreen;

        private readonly LevelContext _levelContext;

        private readonly IAudioService _audio;
        private readonly int _level;
        private readonly IUiCloseService _uiClose;
        private readonly Ecs.Game _game;
        private readonly IDiBuilder _diBuilder;
        private readonly LoadingScreen _loadingScreen;
        private readonly IFpsService _fpsService;
        private readonly CoroutineContext _coroutineContext;

        public GameController()
        {
            IUiService ui = DiContainer.Resolve<IUiService>();
            _fpsService = DiContainer.Resolve<IFpsService>();


            _diBuilder = DiBuilder.Create();

            _diBuilder.Register<CarInputService, ICarInputService>();
            _diBuilder.Register<PlayerInputService, IPlayerInputService>();

            _game = new Ecs.Game();
            
            _levelScreen = ui.Get<LevelScreen>();
            _loadingScreen = ui.Get<LoadingScreen>();
            _carInputScreen = ui.Get<CarInputScreen>();

            _uiClose = DiContainer.Resolve<IUiCloseService>();

            _audio = DiContainer.Resolve<IAudioService>();

            _coroutineContext = new CoroutineContext();

        }
        
        public void StartGame()
        {
            //_audio.PlayMusic(MusicType.RoadNoise);
            
            _levelScreen.Open(_level);
            _levelScreen.EnableRestartButton();

            _game.StartGame();
            
            _coroutineContext.RunWithDelay(5f, () =>
            {
                _loadingScreen.Close();
            });
        }

        public void FinishGame()
        {
            _game.FinishGame();
            _audio.StopAll();
            _uiClose.CloseAll();

            _diBuilder.Dispose();
        }
    }
}