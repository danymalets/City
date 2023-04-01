using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Game.UI.Overlays
{
    public class DebugMenuOverlayScreen : WindowBase.Screens.Screen
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