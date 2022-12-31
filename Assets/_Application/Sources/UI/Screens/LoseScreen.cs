using System;
using Sources.UI.WindowBase.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Screens
{
    public class LoseScreen : SimpleScreen
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