using UnityEngine;
using UnityEngine.UI;
using Screen = Sources.Services.Ui.WindowBase.Screens.Screen;

namespace Sources.App.Game.UI.Overlays
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