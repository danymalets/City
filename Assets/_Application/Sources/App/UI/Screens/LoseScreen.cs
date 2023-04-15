using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Application.Sources.App.UI.Screens
{
    public class LoseScreen : CommonServices.UiServices.WindowBase.Screens.Screen
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