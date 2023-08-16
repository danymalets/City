using Sources.Services.UiServices.WindowBase.Screens;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Overlays
{
    public class DebugMenuScreen : GameScreen
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