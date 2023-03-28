using System;
using Sources.Game.Controllers.InputControllers;
using Sources.Game.Ecs;
using Sources.Game.Ecs.MonoEntities;
using Sources.Game.InputServices;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using Sources.Infrastructure.Services.Audio;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.CoroutineRunner;
using Sources.Infrastructure.Services.Fps;
using Sources.Infrastructure.Services.Pool;
using Sources.UI.Screens;
using Sources.UI.Screens.Input;
using Sources.UI.Screens.Level;
using Sources.UI.System;
using UnityEngine;

namespace Sources.Game.Controllers
{
    public class GameController
    {
        private readonly LevelScreen _levelScreen;
        private readonly CarInputScreen _carInputScreen;

        private readonly LevelBalance _balance;
        private readonly LevelContext _levelContext;

        private readonly IAudioService _audio;
        private readonly int _level;
        private readonly IUiCloseService _uiClose;
        private readonly InputController _inputController;
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

            _inputController = new InputController();
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