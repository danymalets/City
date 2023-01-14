using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Audio;
using Sources.UI.Screens;
using Sources.UI.Screens.Input;
using Sources.UI.System;

namespace Sources.Game.Controllers.FinishGameControllers
{
    public class LoseController : StatusController
    {
        private readonly LoseScreen _loseScreen;
        private readonly CarInputScreen _carInputScreen;

        public LoseController()
        {
            _loseScreen = DiContainer.Resolve<IUiService>()
                .Get<LoseScreen>();
        }

        public void Lose()
        {
            _audio.PlayOnce(SoundEffectType.Lose);
            
            DisableInputAndRetryButton();
            _loseScreen.Open();
        }
    }
}