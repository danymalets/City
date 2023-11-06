using System;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.Wallets;
using UnityEngine;

namespace Sources.App.Ui.Screens.CurrencyScreens.CurrencyItems
{
    public class CurrencyItemController
    {
        private readonly CurrencyItem _currencyItem;
        private readonly UserCurrency _userCurrency;
        private readonly Action _buyButtonAction;

        public CurrencyItemController(CurrencyItem currencyItem, UserCurrency userCurrency, Action buyButtonAction)
        {
            _currencyItem = currencyItem;
            _userCurrency = userCurrency;
            _buyButtonAction = buyButtonAction;
        }

        public void OnOpen()
        {
            _currencyItem.Text.text = _userCurrency.Value.ToString();
            
            _userCurrency.Changed += UserCurrency_OnChanged;
            _currencyItem.BuyButton.onClick.AddListener(BuyButton_OnClicked);
        }

        public void OnClose()
        {
            _userCurrency.Changed -= UserCurrency_OnChanged;
            _currencyItem.BuyButton.onClick.RemoveListener(BuyButton_OnClicked);
        }

        private void UserCurrency_OnChanged(long value)
        {
            _currencyItem.Text.text = _userCurrency.Value.ToString();
        }

        private void BuyButton_OnClicked()
        {
            _buyButtonAction?.Invoke();
        }
    }
}