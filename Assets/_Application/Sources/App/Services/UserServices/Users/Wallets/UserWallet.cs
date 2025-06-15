using System;
using Newtonsoft.Json;

namespace Sources.App.Services.UserServices.Users.Wallets
{
    public class UserWallet
    {
        [JsonProperty] public UserCurrency Coins { get; } = new();
        [JsonProperty] public UserCurrency Gems { get; } = new();

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