using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.Wallets;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.ShopScreens.GemsForCoinsExchanges
{
    public class CoinsForGemsItemController
    {
        private readonly CoinsForGemsItem _item;
        private readonly CoinsForGemsBalance _balance;
        private readonly UserWallet _userWallet;

        public CoinsForGemsItemController(CoinsForGemsItem item, CoinsForGemsBalance balance)
        {
            _balance = balance;
            _userWallet = DiContainer.Resolve<IUserAccessService>().User.UserWallet;
            _item = item;
        }

        public void OnSetup()
        {
            _item.ExchangeButton.onClick.AddListener(OnExchangeClicked);
        }
        
        public void OnCleanup()
        {
            _item.ExchangeButton.onClick.RemoveListener(OnExchangeClicked);
        }
        
        private void OnExchangeClicked()
        {
            if (_userWallet.Gems.TrySpend(_balance.Gems))
            {
                _userWallet.Coins.AddCurrency(_balance.Coins);
            }
        }
    }
}