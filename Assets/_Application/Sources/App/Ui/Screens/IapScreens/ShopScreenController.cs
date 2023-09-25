using System.Linq;
using Sources.App.Services.AssetsServices.Localizations;
using Sources.App.Services.UserServices;
using Sources.App.Ui.Base;
using Sources.App.Ui.Base.Animators;
using Sources.App.Ui.Screens.IapScreens.IapItems;
using Sources.Services.ApplicationServices;
using Sources.Services.IapServices;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Ui.Screens.IapScreens
{
    public class ShopScreenController : ScreenController
    {
        private readonly ShopScreen _shopScreen;
        private readonly IIapService _iapService;
        private readonly IapItemController[] _iapItemsControllers;
        private readonly IUserAccessService _userAccessService;
        private readonly IApplicationService _applicationService;

        public ShopScreenController(ShopScreen shopScreen) : base(shopScreen, new ToggleAnimator(shopScreen))
        {
            _shopScreen = shopScreen;

            IapItem[] iapItems =
            {
                _shopScreen.Buy500CoinsButton,
                _shopScreen.Buy1000CoinsButton,
                _shopScreen.BuyRedCarButton,
                _shopScreen.BuyGreenCarButton,
                _shopScreen.RemoveAdsButton,
            };

            _iapItemsControllers = iapItems.Select(iapItem => new IapItemController(iapItem)).ToArray();

            _userAccessService = DiContainer.Resolve<IUserAccessService>();
            _applicationService = DiContainer.Resolve<IApplicationService>();
            _iapService = DiContainer.Resolve<IIapService>();
        }

        protected override void OnOpen()
        {
            foreach (IapItemController iapItemController in _iapItemsControllers)
            {
                iapItemController.OnOpen();
            }
            
            _shopScreen.RestorePurchasesTextButton.gameObject
                .SetActive(_applicationService.ApplicationPlatform == RuntimePlatform.IPhonePlayer);

            _shopScreen.RestorePurchasesTextButton.Button.onClick.AddListener(OnRestorePurchasesButtonClicked);

            _iapService.Initialized += IapService_OnInitialized;
            _iapService.PurchaseProcessed += IapService_OnPurchaseProcessed;
        }

        protected override void OnClose()
        {
            foreach (IapItemController iapItemController in _iapItemsControllers)
            {
                iapItemController.OnClose();
            }

            _iapService.Initialized -= IapService_OnInitialized;
            _iapService.PurchaseProcessed -= IapService_OnPurchaseProcessed;
        }
        
        protected override void OnRefresh(StringsAsset strings)
        {
            _shopScreen.ShopTitle.text = strings.Shop;
            
            _shopScreen.Buy500CoinsButton.TitleText.text = string.Format(strings.CoinsPattern, 500);
            _shopScreen.Buy1000CoinsButton.TitleText.text = string.Format(strings.CoinsPattern, 1000);
            _shopScreen.BuyRedCarButton.TitleText.text = strings.RedCar;
            _shopScreen.BuyGreenCarButton.TitleText.text = strings.GreenCar;
            _shopScreen.RemoveAdsButton.TitleText.text = strings.RemoveAds;
            
            _shopScreen.RestorePurchasesTextButton.Text.text = strings.RestorePurchases;

            _shopScreen.BuyRedCarButton.BoughtPanel.SetActive(_userAccessService.User.Progress.IsRedCarUnlocked);
            _shopScreen.BuyGreenCarButton.BoughtPanel.SetActive(_userAccessService.User.Progress.IsGreenCarUnlocked);
            _shopScreen.RemoveAdsButton.BoughtPanel.SetActive(_userAccessService.User.IsRemoveAds);

            foreach (IapItemController iapItemController in _iapItemsControllers)
            {
                iapItemController.OnRefresh(strings);
            }
        }

        private void IapService_OnInitialized()
        {
            Refresh();
        }

        private void IapService_OnPurchaseProcessed()
        {
            Refresh();
        }

        private void OnRestorePurchasesButtonClicked()
        {
            _iapService.RestorePurchases();
        }
    }
}