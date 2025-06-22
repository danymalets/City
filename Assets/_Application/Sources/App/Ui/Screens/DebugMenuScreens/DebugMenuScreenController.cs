using System.Linq;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.Wallets;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Screens.DebugMenuScreens.DebugMenus;
using Sources.App.Ui.Screens.DebugMenuScreens.Providers;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using static TMPro.TMP_InputField;

namespace Sources.App.Ui.Screens.DebugMenuScreens
{
    public class DebugMenuScreenController : ScreenController
    {
        private readonly DebugMenuScreen _debugMenuScreen;
        private readonly DebugMenuViewController _debugMenuViewController;
        private IUserAccessService _userAccessService;

        public DebugMenuScreenController(DebugMenuScreen debugMenuScreen) : 
            base(debugMenuScreen, new ToggleAnimator(debugMenuScreen), true)
        {
            _debugMenuScreen = debugMenuScreen;
            _debugMenuViewController = new DebugMenuViewController(_debugMenuScreen.DebugMenu);
            
        }

        protected override void OnCreate()
        {
            base.OnCreate();
            
            _userAccessService = DiContainer.Resolve<IUserAccessService>();

#if FORCE_DEBUG
            _debugMenuViewController.Initialize(new DebugItemProvider[]
            {
                new SetCurrencyDebugItemProvider(CurrencyType.Coins, 10_000),
                new SetCurrencyDebugItemProvider(CurrencyType.Gems, 100),
                new ResetUserItemProvider(),
                new RunGameDebugItemProvider(),
            }.Select(itemProvider => itemProvider.GetItem()));
#endif
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