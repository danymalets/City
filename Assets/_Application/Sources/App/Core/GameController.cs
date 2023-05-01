using Sources.App.Core.Services;
using Sources.App.Data.Common;
using Sources.App.Services.AudioServices;
using Sources.App.UI.Screens;
using Sources.App.UI.Screens.Input;
using Sources.App.UI.Screens.Level;
using Sources.App.UI.Screens.Map;
using Sources.CommonServices.CoroutineRunnerServices;
using Sources.CommonServices.FpsServices;
using Sources.CommonServices.UiServices.System;
using Sources.Utils.Di;

namespace Sources.App.Core
{
    public class GameController
    {
        private readonly LevelScreen _levelScreen;
        private readonly CarInputScreen _carInputScreen;

        private readonly ILevelContext _levelContext;

        private readonly IAudioService _audio;
        private readonly int _level;
        private readonly IUiCloseService _uiClose;
        private readonly Ecs.Game _game;
        private readonly IDiBuilder _diBuilder;
        private readonly LoadingScreen _loadingScreen;
        private readonly IFpsService _fpsService;
        private readonly CoroutineContext _coroutineContext;
        private readonly MapScreen _mapScreen;

        public GameController()
        {
        
            IUiService ui = DiContainer.Resolve<IUiService>();
            _fpsService = DiContainer.Resolve<IFpsService>();


            _diBuilder = DiBuilder.Create();

            _diBuilder.Register<CarInputService, ICarInputService>();
            _diBuilder.Register<PlayerInputService, IPlayerInputService>();

            _game = new Ecs.Game();
            
            _levelScreen = ui.Get<LevelScreen>();
            _mapScreen = ui.Get<MapScreen>();
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
            _mapScreen.Open();
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