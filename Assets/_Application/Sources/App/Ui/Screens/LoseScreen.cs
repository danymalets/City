using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens
{
    public class LoseScreen : Sources.Services.UiServices.WindowBase.Screens.GameScreen
    {
        public event Action RetryButtonClicked = delegate { };

        [SerializeField]
        private Button _retryButton;

        private void Awake()
        {
            _retryButton.onClick.AddListener(() => RetryButtonClicked());
        }
    }
}