using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Game.UI.Screens
{
    public class LoseScreen : WindowBase.Screens.Screen
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