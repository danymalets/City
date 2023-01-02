using Sources.Game.Controllers.InputControllers;
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

namespace Sources.Game.Controllers
{
    public class GameController
    {
        private readonly TapToStartScreen _tapToStartScreen;
        private readonly LevelScreen _levelScreen;
        private readonly InputScreen _inputScreen;

        private readonly LevelBalance _balance;
        private readonly LevelContext _levelContext;

        private readonly IAudioService _audio;
        private readonly int _level;
        private readonly IUiCloseService _uiClose;
        private readonly InputController _inputController;
        private readonly NpcWithCarController _npcWithCarController;

        public GameController(int level, LevelBalance levelBalance, LevelContext levelContext)
        {
            _level = level;
            _balance = levelBalance;
            _levelContext = levelContext;

            IUiService ui = DiContainer.Resolve<IUiService>();
            _uiClose = DiContainer.Resolve<IUiCloseService>();

            _levelScreen = ui.Get<LevelScreen>();
            _tapToStartScreen = ui.Get<TapToStartScreen>();
            _inputScreen = ui.Get<InputScreen>();

            _npcWithCarController = new NpcWithCarController();

            _audio = DiContainer.Resolve<IAudioService>();

            _inputController = new InputController();
        }

        public void StartGame()
        {
            _audio.PlayMusic(MusicType.RoadNoise);

            _levelScreen.Open(_level);
            _tapToStartScreen.Open();
            
            _npcWithCarController.StartSpawn();

            _tapToStartScreen.Tapped += TapToStartScreenClicked;
        }

        private void TapToStartScreenClicked()
        {
            _levelScreen.EnableRestartButton();
            _tapToStartScreen.Tapped -= TapToStartScreenClicked;
            
            _inputController.StartGame();

            _inputScreen.Open();
        }

        public void EndGame()
        {
            _inputController.Cleanup();

            _audio.StopAll();
            _uiClose.CloseAll();
        }
    }
}