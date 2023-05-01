using Sources.App.Services.AudioServices;
using Sources.App.Services.UserServices;
using Sources.Services.UiServices.WindowBase.Popups;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.UI.Popups.Settings
{
    public class SettingsPopup : Popup
    {
        [SerializeField]
        private SwitchableButton _musicButton;
        
        [SerializeField]
        private SwitchableButton _soundsButton;
        
        [SerializeField]
        private SwitchableButton _vibrationButton;

        private IAudioService _audio;

        protected override void OnOpen()
        {
            Preferences preferences = DiContainer.Resolve<IUserAccessService>()
                .User.Preferences;
            
            _musicButton.Setup(preferences.MusicOn);
            _soundsButton.Setup(preferences.SoundsOn);
            _vibrationButton.Setup(preferences.VibrationsOn);

            _audio = DiContainer.Resolve<IAudioService>();
        }

        protected override void OnRefresh()
        {
        }

        protected override void OnCloseButtonClicked()
        {
            _audio.PlayOnce(SoundEffectType.ButtonClick);
        }

        protected override void OnClose()
        {
            _musicButton.Cleanup();
            _soundsButton.Cleanup();
            _vibrationButton.Cleanup();

            _audio = null;
        }

        protected override bool ShouldStopTime => true;
        protected override bool ShouldCloseOnBackButtonClicked => true;
    }
}