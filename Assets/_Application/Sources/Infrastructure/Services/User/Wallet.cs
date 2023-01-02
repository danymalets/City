using System;

namespace Sources.Infrastructure.Services.User
{
    public class Wallet
    {
        public Currency Coins { get; } = new();
        public Currency Gems { get; } = new();

        public bool TrySpend(CurrencyType currencyType, long spendValue) =>
            GetCurrency(currencyType).TrySpend(spendValue);

        public void AddCurrency(CurrencyType currencyType, long value) =>
            GetCurrency(currencyType).AddCurrency(value);
        
        public Currency GetCurrency(CurrencyType type)
        {
            return type switch
            {
                CurrencyType.Coins => Coins,
                CurrencyType.Gems => Gems,
                _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
            };
        }
    }
}