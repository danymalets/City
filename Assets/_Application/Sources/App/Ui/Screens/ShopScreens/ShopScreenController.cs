using System.Collections.Generic;
using System.Linq;
using Sirenix.Utilities;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.App.Services.UserServices;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Base.Controllers;
using Sources.App.Ui.Screens.ShopScreens.GemIapsViews;
using Sources.App.Ui.Screens.ShopScreens.GemsForCoinsExchanges;
using Sources.App.Ui.Screens.ShopScreens.IapItems;
using Sources.Services.ApplicationServices;
using Sources.Services.IapServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Ui.Screens.ShopScreens
{
    public class ShopScreenController : ScreenController
    {
        private readonly ShopScreen _shopScreen;
        private readonly IIapService _iapService;
        private readonly IApplicationService _applicationService;
        private IapItemController[] _iapItemControllers;
        private readonly CoinsForGemsViewController _coinsForGemsViewController;
        private readonly GemIapsViewController _gemIapsViewController;
        
        public ShopScreenController(ShopScreen shopScreen) : base(shopScreen, new ToggleAnimator(shopScreen))
        {
            _shopScreen = shopScreen;
            _applicationService = DiContainer.Resolve<IApplicationService>();
            _iapService = DiContainer.Resolve<IIapService>();

            _iapItemControllers = new[]
            {
                new IapItemController(_shopScreen.IapRedCarItem, IapProductType.RedCar),
                new IapItemController(_shopScreen.GreenCarItem, IapProductType.GreenCar),
                new IapItemController(_shopScreen.RemoveAdsItem, IapProductType.RedCar),
            };

            _coinsForGemsViewController = new CoinsForGemsViewController(shopScreen.CoinsForGemsItems);
            _gemIapsViewController = new GemIapsViewController(shopScreen.IapGemItems);
        }

        protected override void OnCreate()
        {
            _shopScreen.RestorePurchasesTextButton.gameObject
                .SetActive(_applicationService.ApplicationPlatform == RuntimePlatform.IPhonePlayer);
        }

        protected override void OnOpen()
        {
            _coinsForGemsViewController.OnSetup();
            _gemIapsViewController.OnSetup();
            
            foreach (IapItemController iapItemController in _iapItemControllers)
            {
                iapItemController.OnSetup();
            }

            _shopScreen.RestorePurchasesTextButton.Button.onClick.AddListener(OnRestorePurchasesButtonClicked);

            _iapService.Initialized += IapService_OnInitialized;
        }

        protected override void OnClose()
        {
            _coinsForGemsViewController.OnCleanup();
            _gemIapsViewController.OnCleanup();

            foreach (IapItemController iapItemController in _iapItemControllers)
            {
                iapItemController.OnCleanup();
            }

            _shopScreen.RestorePurchasesTextButton.Button.onClick.AddListener(OnRestorePurchasesButtonClicked);

            _iapService.Initialized -= IapService_OnInitialized;
        }

        protected override void OnRefresh()
        {
            _shopScreen.ShopTitle.text = Strings.Shop;

            _shopScreen.IapRedCarItem.TitleText.text = Strings.RedCar;
            _shopScreen.GreenCarItem.TitleText.text = Strings.GreenCar;
            _shopScreen.RemoveAdsItem.TitleText.text = Strings.RemoveAds;

            _shopScreen.RestorePurchasesTextButton.Text.text = Strings.RestorePurchases;

            foreach (IapItemController iapItemController in _iapItemControllers)
            {
                iapItemController.OnRefresh();
            }

            _gemIapsViewController.OnRefresh();
            _coinsForGemsViewController.OnRefresh();
        }

        private void IapService_OnInitialized()
        {
            Refresh();
        }

        private void OnRestorePurchasesButtonClicked()
        {
            _iapService.RestorePurchases();
        }
    }
}