using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Audio;
using Sources.UI.Screens.Input;
using Sources.UI.Screens.Level;
using Sources.UI.System;

namespace Sources.Game.Controllers.EndController
{
    public abstract class StatusController
    {
        private readonly InputScreen _inputScreen;
        private readonly LevelScreen _levelScreen;
        protected readonly IAudioService _audio;

        protected StatusController()
        {
            _inputScreen = UiSystem.Get<InputScreen>();
            _levelScreen = UiSystem.Get<LevelScreen>();
            _audio = DiContainer.Resolve<IAudioService>();
        }
        
        protected void DisableInputAndRetryButton()
        {
            _inputScreen.Close();
            _levelScreen.DisableRestartButton();
        }
    }
}