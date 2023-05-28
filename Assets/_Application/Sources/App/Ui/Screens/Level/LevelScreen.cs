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
    public class LevelScreen : GameScreen<int>
    {
        private const string LevelTextPattern = "LEVEL {0}";

        [field: SerializeField] public Button ExitButton { get; private set; }
        [field: SerializeField] public CoinsView CoinsView { get; private set; }

        [SerializeField]
        private TextMeshProUGUI _levelText;

        [SerializeField]
        private Button _settingsButton;
        
        [SerializeField]
        private Button _restartButton;

        private IAudioService _audio;
        private SettingsPopup _settingsPopup;

        public event Action RestartButtonClicked = delegate { };
        public event Action ExitButtonClicked = delegate { };
        
        protected override void OnSetup()
        {
            _settingsPopup = Ui.Get<SettingsPopup>();

            _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
            _restartButton.onClick.AddListener(OnRestartButtonClicked);
            ExitButton.onClick.AddListener(OnExitButtonClicked);
        }

        private void OnExitButtonClicked()
        {
            ExitButtonClicked?.Invoke();
        }

        protected override void OnRefresh()
        {
        }

        protected override void OnOpen(int level)
        {
            _audio = DiContainer.Resolve<IAudioService>();
            
            _levelText.text = string.Format(LevelTextPattern, level);
        }

        protected override void OnClose()
        {
            
        }

        private void OnRestartButtonClicked()
        {
            RestartButtonClicked();
        }

        private void OnSettingsButtonClicked()
        {
            _settingsPopup.Open();
        }
    }
}