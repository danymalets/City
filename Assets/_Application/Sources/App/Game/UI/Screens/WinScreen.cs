using System;
using UnityEngine;
using UnityEngine.UI;
using Screen = Sources.Services.Ui.WindowBase.Screens.Screen;

namespace Sources.App.Game.UI.Screens
{
    public class WinScreen : Screen
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