using System;
using Sources.App.Services.AudioServices;
using Sources.App.Ui.Popups.Settings;
using Sources.Services.UiServices.WindowBase.Screens;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.Level
{
    public class LevelScreen : Screen<int>
    {
        private const string LevelTextPattern = "LEVEL {0}";

        [SerializeField]
        private TextMeshProUGUI _levelText;

        [SerializeField]
        private Button _settingsButton;
        
        [SerializeField]
        private Button _restartButton;

        private IAudioService _audio;
        private SettingsPopup _settingsPopup;

        public event Action RestartButtonClicked = delegate { };
        
        protected override void OnSetup()
        {
            _settingsPopup = Ui.Get<SettingsPopup>();

            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
        }

        protected override void OnRefresh()
        {
        }

        protected override void OnOpen(int level)
        {
            _audio = DiContainer.Resolve<IAudioService>();
            
            _levelText.text = string.Format(LevelTextPattern, level);

            DisableRestartButton();
        }

        protected override void OnClose()
        {
            
        }

        public void EnableRestartButton() => 
            _restartButton.gameObject.Enable();

        public void DisableRestartButton() => 
            _restartButton.gameObject.Disable();

        private void OnRestartButtonClicked()
        {
            _audio.PlayOnce(SoundEffectType.ButtonClick);
            RestartButtonClicked();
        }

        private void OnSettingsButtonClicked()
        {
            _audio.PlayOnce(SoundEffectType.ButtonClick);
            _settingsPopup.Open();
        }
    }
}