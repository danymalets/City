using Sources.Data;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Audio;
using Sources.Infrastructure.Services.Audio.Clips.Type;
using Sources.UI.WindowBase.Popups;
using UnityEngine;

namespace Sources.UI.Popups.Settings
{
    public class SettingsPopup : SimplePopup
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
            _musicButton.Setup(Prefs.MusicEnabled);
            _soundsButton.Setup(Prefs.SoundEffectsEnabled);
            _vibrationButton.Setup(Prefs.VibrationEnabled);

            _audio = DiContainer.Resolve<IAudioService>();
        }

        protected override void OnClose()
        {
            _musicButton.Cleanup();
            _soundsButton.Cleanup();
            _vibrationButton.Cleanup();
        }

        protected override void OnCloseButtonClicked()
        {
            _audio.PlayOnce(SoundEffectType.ButtonClick);
        }

        protected override bool ShouldStopTime => true;
        protected override bool ShouldCloseOnBackButtonClicked => true;
    }
}