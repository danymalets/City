using System;
using UnityEngine;
using UnityEngine.UI;
using Screen = Sources.Services.UiServices.WindowBase.Screens.Screen;

namespace Sources.App.Ui.Screens
{
    public class LoseScreen : Screen
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