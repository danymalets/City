using System;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Screens.IapScreens;
using Sources.App.Ui.Screens.SettingsScreens;
using Sources.Services.ApplicationServices;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.MainScreens
{
    public class MainScreenController : ScreenController
    {
        private readonly MainScreen _mainScreen;
        private ShopScreenController _shopScreenController;
        private readonly IApplicationService _applicationService;
        private SettingsScreenController _settingsScreenController;

        public event Action PlayButtonClicked;

        public MainScreenController(MainScreen mainScreen) :
            base(mainScreen, new ToggleAnimator(mainScreen))
        {
            _mainScreen = mainScreen;
            _applicationService = DiContainer.Resolve<IApplicationService>();
        }

        protected override void OnOpen()
        {
            IUiControllersService uiControllers = DiContainer.Resolve<IUiControllersService>();
            _shopScreenController = uiControllers.Get<ShopScreenController>();
            _settingsScreenController = uiControllers.Get<SettingsScreenController>();

            _mainScreen.PlayTextButton.Button.onClick.AddListener(OnPlayButtonClicked);
            _mainScreen.ShopTextButton.Button.onClick.AddListener(OnShopButtonClicked);
            _mainScreen.SettingsTextButton.Button.onClick.AddListener(OnSettingsButtonClicked);
            _mainScreen.RateUsTextButton.Button.onClick.AddListener(OnRateUsButtonClicked);
        }

        protected override void OnClose()
        {
            _mainScreen.PlayTextButton.Button.onClick.RemoveListener(OnPlayButtonClicked);
            _mainScreen.ShopTextButton.Button.onClick.RemoveListener(OnShopButtonClicked);
            _mainScreen.SettingsTextButton.Button.onClick.RemoveListener(OnSettingsButtonClicked);
            _mainScreen.RateUsTextButton.Button.onClick.RemoveListener(OnRateUsButtonClicked);

            _shopScreenController = null;
        }

        protected override void OnRefresh()
        {
            _mainScreen.PlayTextButton.Text.text = Strings.Play;
            _mainScreen.ShopTextButton.Text.text = Strings.Shop;
            _mainScreen.SettingsTextButton.Text.text = Strings.Settings;
            _mainScreen.RateUsTextButton.Text.text = Strings.RateUs;
        }

        private void OnPlayButtonClicked()
        {
            PlayButtonClicked?.Invoke();
        }

        private void OnShopButtonClicked()
        {
            _shopScreenController.Open();
        }

        private void OnSettingsButtonClicked()
        {
            _settingsScreenController.Open();
        }

        private void OnRateUsButtonClicked()
        {
            _applicationService.OpenUrl("http://google.com");
        }
    }
}