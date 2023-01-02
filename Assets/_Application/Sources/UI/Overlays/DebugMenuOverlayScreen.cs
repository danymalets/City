using System;
using UnityEngine;
using UnityEngine.UI;
using Screen = Sources.UI.WindowBase.Screens.Screen;

namespace Sources.UI.Overlays
{
    public class DebugMenuOverlayScreen : Screen
    {
        [SerializeField]
        private Button _openDebugMenuButton;

        private void Awake()
        {
            _openDebugMenuButton.onClick.AddListener(OnOpenDebugMenuButtonClicked);
        }

        private void OnOpenDebugMenuButtonClicked()
        {
            OpenDebugMenu();
        }

        private void OpenDebugMenu()
        {
            
        }
    }
}