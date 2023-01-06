using Sources.Game.Controllers.InputControllers;
using Sources.Game.Ecs;
using Sources.Game.InputServices;
using Sources.Game.StaticData;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Audio;
using Sources.Infrastructure.Services.Audio.Clips.Type;
using Sources.Infrastructure.Services.Balance;
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
        private readonly InputScreen _inputScreen;

        private readonly LevelBalance _balance;
        private readonly LevelContextService _levelContext;

        private readonly IAudioService _audio;
        private readonly int _level;
        private readonly IUiCloseService _uiClose;
        private readonly InputController _inputController;
        private readonly EcsGame _ecsGame;
        private readonly IDiBuilder _diBuilder;

        public GameController()
        {
            IUiService ui = DiContainer.Resolve<IUiService>();

            _diBuilder = DiBuilder.Create();

            _diBuilder.Register<InputService, IInputService>();

            _levelScreen = ui.Get<LevelScreen>();
            _inputScreen = ui.Get<InputScreen>();

            _uiClose = DiContainer.Resolve<IUiCloseService>();
            
            _audio = DiContainer.Resolve<IAudioService>();

            _ecsGame = new EcsGame();

            _inputController = new InputController();
        }

        public void StartGame()
        {
            //_audio.PlayMusic(MusicType.RoadNoise);

            _levelScreen.Open(_level);
            
            _levelScreen.EnableRestartButton();
            
            _inputScreen.Open();

            
            _ecsGame.StartGame();
        }

        public void FinishGame()
        {
            _ecsGame.FinishGame();
            _audio.StopAll();
            _uiClose.CloseAll();
            
            _diBuilder.Dispose();
        }
    }
}