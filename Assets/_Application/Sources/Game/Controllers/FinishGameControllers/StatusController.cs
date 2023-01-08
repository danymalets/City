using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Audio;
using Sources.UI.Screens.Input;
using Sources.UI.Screens.Level;
using Sources.UI.System;

namespace Sources.Game.Controllers.EndController
{
    public abstract class StatusController
    {
        private readonly CarInputScreen _carInputScreen;
        private readonly LevelScreen _levelScreen;
        protected readonly IAudioService _audio;

        protected StatusController()
        {
            IUiService ui = DiContainer.Resolve<IUiService>(); 
            
            _carInputScreen = ui.Get<CarInputScreen>();
            _levelScreen = ui.Get<LevelScreen>();
            
            _audio = DiContainer.Resolve<IAudioService>();
        }
        
        protected void DisableInputAndRetryButton()
        {
            _carInputScreen.Close();
            _levelScreen.DisableRestartButton();
        }
    }
}