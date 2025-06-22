using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.Wallets;
using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Screens.CurrencyScreens.CurrencyItems;
using Sources.App.Ui.Screens.ShopScreens;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Ui.Screens.CurrencyScreens
{
    public class CurrencyScreenController : ScreenController
    {
        private CurrencyItemController[] _itemControllers;
        private readonly CurrencyScreen _currencyScreen;
        private ShopScreenController _shopScreenController;

        public CurrencyScreenController(CurrencyScreen currencyScreen)
            : base(currencyScreen, new ToggleAnimator(currencyScreen))
        {
            _currencyScreen = currencyScreen;
        }

        protected override void OnCreate()
        {
            _shopScreenController = 
                DiContainer.Resolve<IUiControllersService>().Get<ShopScreenController>();
            
            _itemControllers = new[]
            {
                new CurrencyItemController(_currencyScreen.CoinsItem, CurrencyType.Coins, _shopScreenController.Open),
                new CurrencyItemController(_currencyScreen.GemsItem, CurrencyType.Gems, _shopScreenController.Open),
            };
        }

        protected override void OnOpen()
        {
            foreach (CurrencyItemController itemController in _itemControllers)
            {
                itemController.OnOpen();
            }
        }

        protected override void OnClose()
        {
            foreach (CurrencyItemController itemController in _itemControllers)
            {
                itemController.OnClose();
            }
        }
    }
}