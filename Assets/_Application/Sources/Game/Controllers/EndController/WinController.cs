using Sources.Data;
using Sources.Data.Live;
using Sources.Infrastructure.Services.Audio.Clips.Type;
using Sources.UI.Screens;
using Sources.UI.System;

namespace Sources.Game.Controllers.EndController
{
    public class WinController : StatusController
    {
        private readonly WinScreen _winScreen;
        private readonly LiveInt _currentLevel;

        public WinController()
        {
            _winScreen = UiSystem.Get<WinScreen>();
            _currentLevel = Progress.CurrentLevel;
        }

        public void Win()
        {
            _audio.PlayOnce(SoundEffectType.Win);
            
            _currentLevel.Value++;

            DisableInputAndRetryButton();
            
            _winScreen.Open();
        }
    }
}