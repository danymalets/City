using System;
using Sources.Services.UiServices.WindowBase.Screens;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.Level
{
    public class MainScreen : GameScreen
    {
        [field : SerializeField] public Button PlayButton { get; private set; }
        [field : SerializeField] public TextMeshProUGUI PlayButtonText { get; private set; }

        public event Action PlayClicked;
        
        private void Awake()
        {
            PlayButton.onClick.AddListener(OnPlayButtonClicked);
        }

        private void OnPlayButtonClicked()
        {
            PlayClicked?.Invoke();
        }
    }
}