using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.App.Ui.Screens.ShopScreens.IapItems;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.ShopScreens.GemsForCoinsExchanges
{
    public class CoinsForGemsViewController
    {
        private readonly CoinsForGemsItem[] _items;
        private readonly EconomyBalance _economyBalance;
        private readonly CoinsForGemsItemController[] _itemsControllers;

        public CoinsForGemsViewController(CoinsForGemsItem[] items)
        {
            CoinsForGemsBalance[] products = DiContainer.Resolve<Balance>().EconomyBalance.CoinsForGemsForCoinsExchange;

            DAssert.IsTrue(items.Length == products.Length);
            _itemsControllers = new CoinsForGemsItemController[items.Length];
            for (int i = 0; i < items.Length; i++)
            {
                _itemsControllers[i] = new CoinsForGemsItemController(items[i], products[i]);
            }
        }

        public void OnSetup()
        {
            foreach (CoinsForGemsItemController itemController in _itemsControllers)
            {
                itemController.OnSetup();
            }
        }

        public void OnCleanup()
        {
            foreach (CoinsForGemsItemController itemController in _itemsControllers)
            {
                itemController.OnCleanup();
            }
        }

        public void OnRefresh()
        {
            foreach (CoinsForGemsItemController itemController in _itemsControllers)
            {
                itemController.OnRefresh();
            }
        }
    }
}