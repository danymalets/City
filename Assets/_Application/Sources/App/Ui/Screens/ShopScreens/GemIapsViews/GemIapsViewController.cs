using System.Collections.Generic;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.App.Ui.Screens.ShopScreens.IapItems;
using Sources.Services.IapServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Ui.Screens.ShopScreens.GemIapsViews
{
    public class GemIapsViewController
    {
        private readonly IapItem[] _iapItems;
        private CurrencyIapItemController[] _iapItemsControllers;

        public GemIapsViewController(CurrencyIapItem[] iapItems)
        {
            IapProductType[] products = DiContainer.Resolve<Balance>().EconomyBalance.ShopGemProducts;

            DAssert.IsTrue(iapItems.Length == products.Length);
            _iapItemsControllers = new CurrencyIapItemController[iapItems.Length];
            for (int i = 0; i < iapItems.Length; i++)
            {
                _iapItemsControllers[i] = new CurrencyIapItemController(iapItems[i], products[i]);
            }
        }

        public void OnSetup()
        {
            foreach (CurrencyIapItemController itemController in _iapItemsControllers)
            {
                itemController.OnSetup();
            }
        }

        public void OnCleanup()
        {
            foreach (CurrencyIapItemController itemController in _iapItemsControllers)
            {
                itemController.OnCleanup();
            }
        }

        public void OnRefresh()
        {
            foreach (CurrencyIapItemController itemController in _iapItemsControllers)
            {
                itemController.OnRefresh();
            }
        }
    }
}