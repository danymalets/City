using System;
using UnityEngine;
using UnityEngine.UI;

namespace _Application.Sources.App.UI.Screens
{
    public class WinScreen : CommonServices.UiServices.WindowBase.Screens.Screen
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