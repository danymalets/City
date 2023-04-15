using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.UI.Overlays
{
    public class DebugMenuOverlayScreen : CommonServices.UiServices.WindowBase.Screens.Screen
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