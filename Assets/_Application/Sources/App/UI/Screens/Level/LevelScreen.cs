using System;
using Sources.App.Game.UI.Popups.Settings;
using Sources.Services.Audio;
using Sources.Services.Di;
using Sources.Services.Ui.WindowBase.Screens;
using Sources.Utils.Extensions;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sources.App.Game.UI.Screens.Level
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

        [FormerlySerializedAs("_uiCoinsObserver")]
        [SerializeField]
        private CoinsView _coinsView;

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
            
            _coinsView.Setup();
        }

        protected override void OnClose()
        {
            
            _coinsView.Cleanup();
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

        protected override bool MakeTopOnLoad => true;
    }
}