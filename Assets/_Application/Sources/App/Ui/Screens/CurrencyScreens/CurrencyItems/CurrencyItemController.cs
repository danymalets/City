using System;
using Sources.App.Services.UserServices;
using Sources.App.Services.UserServices.Users.Wallets;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Ui.Screens.CurrencyScreens.CurrencyItems
{
    public class CurrencyItemController
    {
        private readonly CurrencyItem _currencyItem;
        private UserCurrency _userCurrency;
        private readonly Action _buyButtonAction;
        private readonly CurrencyType _currencyType;
        private readonly IUserAccessService _userAccessService;

        public CurrencyItemController(CurrencyItem currencyItem, CurrencyType currencyType, Action buyButtonAction)
        {
            _userAccessService = DiContainer.Resolve<IUserAccessService>();

            _currencyType = currencyType;
            _currencyItem = currencyItem;
            _buyButtonAction = buyButtonAction;
        }

        public void OnOpen()
        {
            _userCurrency = _userAccessService.User.UserWallet.GetCurrency(_currencyType);

            ActualizeViewValue();
            
            _userCurrency.Changed += UserCurrency_OnChanged;
            _currencyItem.BuyButton.onClick.AddListener(BuyButton_OnClicked);
        }

        public void OnClose()
        {
            _userCurrency.Changed -= UserCurrency_OnChanged;
            _currencyItem.BuyButton.onClick.RemoveListener(BuyButton_OnClicked);
            _userCurrency = null;
        }

        private void UserCurrency_OnChanged(long value)
        {
            ActualizeViewValue();
        }

        private void ActualizeViewValue() => 
            _currencyItem.Text.text = _userCurrency.Value.ToString();

        private void BuyButton_OnClicked()
        {
            _buyButtonAction?.Invoke();
        }
    }
}