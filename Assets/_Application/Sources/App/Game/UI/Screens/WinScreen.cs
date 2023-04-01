using System;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Game.UI.Screens
{
    public class WinScreen : WindowBase.Screens.Screen
    {
        public event Action NextButtonClicked = delegate { };

        [SerializeField]
        private Button _nextButton;

        private void Awake()
        {
            _nextButton.onClick.AddListener(() => NextButtonClicked());
        }

        protected override void OnRefresh()
        {
        }
    }
}