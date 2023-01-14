using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Audio;
using Sources.Infrastructure.Services.User;
using Sources.UI.Screens;
using Sources.UI.System;

namespace Sources.Game.Controllers.FinishGameControllers
{
    public class WinController : StatusController
    {
        private readonly WinScreen _winScreen;
        private readonly Progress _progress;

        public WinController()
        {
            _winScreen = DiContainer.Resolve<IUiService>()
                .Get<WinScreen>();
            
            _progress = DiContainer.Resolve<IUserAccessService>()
                .User.Progress;
        }

        public void Win()
        {
            _audio.PlayOnce(SoundEffectType.Win);
            
            _progress.CurrentLevel++;

            DisableInputAndRetryButton();
            
            _winScreen.Open();
        }
    }
}