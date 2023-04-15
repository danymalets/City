using System;
using UnityEngine;
using UnityEngine.UI;
using Screen = Sources.Services.Ui.WindowBase.Screens.Screen;

namespace Sources.App.Game.UI.Screens
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