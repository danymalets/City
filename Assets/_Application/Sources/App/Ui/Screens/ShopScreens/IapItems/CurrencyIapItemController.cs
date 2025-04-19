using Sources.App.Services.AssetsServices.Localizations;
using Sources.Services.IapServices;

namespace Sources.App.Ui.Screens.ShopScreens.IapItems
{
    public class CurrencyIapItemController : IapItemController
    {
        private readonly IapItem _currencyIapItem;
        
        public CurrencyIapItemController(IapItem iapItem, IapProductType iapProductType) : base(iapItem, iapProductType)
        {
            _currencyIapItem = iapItem;
        }

        public override void OnRefresh(StringsAsset strings)
        {
            base.OnRefresh(strings);
            _currencyIapItem.CountText.text = _iapProductType.GetGemsCount().ToString();
        }
    }
}