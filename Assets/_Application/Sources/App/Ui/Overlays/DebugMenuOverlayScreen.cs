using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Overlays
{
    public class DebugMenuOverlayScreen : Sources.Services.UiServices.WindowBase.Screens.GameScreen
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