using System;
using Sources.UI.WindowBase.Screens;
using UnityEngine;
using UnityEngine.UI;
using Screen = Sources.UI.WindowBase.Screens.Screen;

namespace Sources.UI.Screens
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