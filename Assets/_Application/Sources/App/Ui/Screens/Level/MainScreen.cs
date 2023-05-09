using System;
using UnityEngine;
using UnityEngine.UI;
using Screen = Sources.Services.UiServices.WindowBase.Screens.Screen;

namespace Sources.App.Ui.Screens.Level
{
    public class MainScreen : Screen
    {
        [SerializeField]
        private Button _playButton;

        public event Action PlayClicked;
        
        private void Awake()
        {
            _playButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            PlayClicked?.Invoke();
        }
    }
}