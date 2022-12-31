using Sources.Infrastructure.Services.Audio.Clips.Type;
using Sources.UI.Screens;
using Sources.UI.Screens.Input;
using Sources.UI.System;

namespace Sources.Game.Controllers.EndController
{
    public class LoseController : StatusController
    {
        private readonly LoseScreen _loseScreen;
        private readonly InputScreen _inputScreen;

        public LoseController()
        {
            _loseScreen = UiSystem.Get<LoseScreen>();
        }

        public void Lose()
        {
            _audio.PlayOnce(SoundEffectType.Lose);
            
            DisableInputAndRetryButton();
            _loseScreen.Open();
        }
    }
}