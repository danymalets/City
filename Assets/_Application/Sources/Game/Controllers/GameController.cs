using Sources.Game.Controllers.InputControllers;
using Sources.Game.StaticData;
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
        private readonly LevelStaticData _staticData;

        private readonly IAudioService _audio;
        private readonly int _level;
        private readonly ICloseableUIService _closeableUI;
        private readonly InputController _inputController;
        private readonly NpcWithCarController _npcWithCarController;

        public GameController(int level, LevelBalance levelBalance, LevelStaticData staticData)
        {
            _level = level;
            _balance = levelBalance;
            _staticData = staticData;

            _closeableUI = DiContainer.Resolve<ICloseableUIService>();

            _levelScreen = UiSystem.Get<LevelScreen>();
            _tapToStartScreen = UiSystem.Get<TapToStartScreen>();
            _inputScreen = UiSystem.Get<InputScreen>();

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
            _closeableUI.CloseAll();
        }
    }
}