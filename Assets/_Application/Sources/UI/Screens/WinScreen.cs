using System;
using Sources.UI.WindowBase.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.UI.Screens
{
    public class WinScreen : SimpleScreen
    {
        public event Action NextButtonClicked = delegate { };

        [SerializeField]
        private Button _nextButton;

        private void Awake()
        {
            _nextButton.onClick.AddListener(() => NextButtonClicked());
        }
    }
}