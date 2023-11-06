using Sources.App.Services.AssetsServices.Localizations;
using Sources.Services.IapServices;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.ShopScreens.IapItems
{
    public class IapItemController
    {
        private readonly IapItem _iapItem;
        private readonly IIapService _iapService;
        protected readonly IapProductType _iapProductType;

        public IapItemController(IapItem iapItem, IapProductType iapProductType)
        {
            _iapItem = iapItem;
            _iapProductType = iapProductType;
            _iapService = DiContainer.Resolve<IIapService>();
        }

        public void OnSetup()
        {
            _iapItem.Button.onClick.AddListener(OnButtonClicked);
        }

        public void OnCleanup()
        {
            _iapItem.Button.onClick.RemoveListener(OnButtonClicked);
        }

        public virtual void OnRefresh()
        {
            _iapItem.PriceText.text = _iapService.GetPriceString(_iapProductType);
        }

        private void OnButtonClicked()
        {
            _iapService.InitiatePurchase(_iapProductType);
        }
    }
}