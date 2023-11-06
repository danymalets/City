using Sources.Services.IapServices;

namespace Sources.App.Ui.Screens.ShopScreens.IapItems
{
    public class CurrencyIapItemController : IapItemController
    {
        private readonly CurrencyIapItem _currencyIapItem;
        
        public CurrencyIapItemController(CurrencyIapItem iapItem, IapProductType iapProductType) : base(iapItem, iapProductType)
        {
            _currencyIapItem = iapItem;
        }

        public override void OnRefresh()
        {
            base.OnRefresh();
            _currencyIapItem.CountText.text = _iapProductType.GetGemsCount().ToString();
        }
    }
}