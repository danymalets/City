using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.Utils.CommonUtils.Extensions;

namespace Sources.App.Ui.Screens.DebugMenuScreens
{
    public class DebugMenuScreenController : ScreenController
    {
        private readonly DebugMenuScreen _debugMenuScreen;

        public DebugMenuScreenController(DebugMenuScreen debugMenuScreen) : 
            base(debugMenuScreen, new ToggleAnimator(debugMenuScreen), true)
        {
            _debugMenuScreen = debugMenuScreen;
        }

        protected override void OnRefresh()
        {
            
        }

        protected override void OnOpen()
        {
            _debugMenuScreen.DebugMenuButton.gameObject.Enable();
            _debugMenuScreen.DebugMenu.gameObject.Disable();

            _debugMenuScreen.DebugMenuButton.onClick.AddListener(OnDebugMenuButtonClicked);
        }

        protected override void OnClose()
        {
            _debugMenuScreen.DebugMenuButton.onClick.RemoveListener(OnDebugMenuButtonClicked);
        }
        
        private void OnDebugMenuButtonClicked()
        {
            _debugMenuScreen.DebugMenu.gameObject.SetActive(!_debugMenuScreen.DebugMenu.gameObject.activeSelf);
        }
    }
}