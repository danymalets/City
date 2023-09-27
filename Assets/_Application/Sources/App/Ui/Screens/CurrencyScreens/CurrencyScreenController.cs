using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Services.UserServices;
using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Screens.CurrencyScreens.CurrencyItems;
using Sources.Services.UiServices.WindowBase.Screens;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.CurrencyScreens
{
    public class CurrencyScreenController : ScreenController
    {
        private readonly CurrencyScreen _currencyScreen;
        private readonly CurrencyItemController _coinsItemController;

        public CurrencyScreenController(CurrencyScreen currencyScreen) 
            : base(currencyScreen, new ToggleAnimator(currencyScreen))
        {
            _currencyScreen = currencyScreen;

            Wallet userWallet = DiContainer.Resolve<IUserAccessService>().User.Wallet;

            _coinsItemController = new CurrencyItemController(_currencyScreen.CoinsItem, userWallet.Coins);
        }

        protected override void OnOpen()
        {
            _coinsItemController.OnOpen();
        }

        protected override void OnClose()
        {
            _coinsItemController.OnClose();
        }

        protected override void OnRefresh()
        {
            
        }
    }
}