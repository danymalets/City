using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.Wallets;

namespace Sources.App.Ui.Screens.CurrencyScreens.CurrencyItems
{
    public class CurrencyItemController
    {
        private readonly CurrencyItem _currencyItem;
        private readonly Currency _currency;

        public CurrencyItemController(CurrencyItem currencyItem, Currency currency)
        {
            _currencyItem = currencyItem;
            _currency = currency;
        }

        public void OnOpen()
        {
            _currency.Changed += Currency_OnChanged;
            _currencyItem.Text.text = _currency.Value.ToString();
        }

        public void OnClose()
        {
            _currency.Changed -= Currency_OnChanged;
        }

        private void Currency_OnChanged(long value)
        {
            _currencyItem.Text.text = _currency.Value.ToString();
        }
    }
}