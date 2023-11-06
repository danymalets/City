using System;

namespace Sources.App.Services.UserServices.Users.Wallets
{
    public class UserWallet
    {
        public UserCurrency Coins { get; } = new(100);
        public UserCurrency Gems { get; } = new(900);

        public bool TrySpend(CurrencyType currencyType, long spendValue) =>
            GetCurrency(currencyType).TrySpend(spendValue);

        public void AddCurrency(CurrencyType currencyType, long value) =>
            GetCurrency(currencyType).AddCurrency(value);
        
        public UserCurrency GetCurrency(CurrencyType type)
        {
            return type switch
            {
                CurrencyType.Coins => Coins,
                CurrencyType.Gems => Gems,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, $"Currency {type} not found")
            };
        }
    }
}