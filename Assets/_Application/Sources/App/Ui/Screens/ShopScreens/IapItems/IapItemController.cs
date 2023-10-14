using Sources.App.Services.AssetsServices.Localizations;
using Sources.Services.IapServices;
using Sources.Utils.Di;

namespace Sources.App.Ui.Screens.ShopScreens.IapItems
{
    public class IapItemController
    {
        private readonly IapItem _iapItem;
        
        private readonly IIapService _iapService;
        
        public IapItemController(IapItem iapItem)
        {
            _iapItem = iapItem;
            _iapService = DiContainer.Resolve<IIapService>();
        }

        public void OnOpen()
        {
            _iapItem.Button.onClick.AddListener(OnButtonClicked);
        }

        public void OnClose()
        {
            _iapItem.Button.onClick.RemoveListener(OnButtonClicked);
        }

        public void OnRefresh(StringsAsset strings)
        {
            _iapItem.PriceText.text = _iapService.GetPriceString(_iapItem.IapProductType);
            _iapItem.BoughtText.text = strings.Bought;
        }

        private void OnButtonClicked()
        {
            _iapService.InitiatePurchase(_iapItem.IapProductType);
        }
    }
}