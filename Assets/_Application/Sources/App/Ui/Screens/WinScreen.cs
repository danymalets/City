using System;
using UnityEngine;
using UnityEngine.UI;
using Screen = Sources.Services.UiServices.WindowBase.Screens.Screen;

namespace Sources.App.Ui.Screens
{
    public class WinScreen : Sources.Services.UiServices.WindowBase.Screens.Screen
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