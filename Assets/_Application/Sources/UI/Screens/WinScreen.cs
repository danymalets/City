using System;
using Sources.UI.WindowBase.Screens;
using UnityEngine;
using UnityEngine.UI;
using Screen = Sources.UI.WindowBase.Screens.Screen;

namespace Sources.UI.Screens
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