using System;
using UnityEngine;

namespace Sources.App.Services.BalanceServices.CommonBalances
{
    [Serializable]
    public struct CoinsForGemsBalance
    {
        [field: SerializeField] public long Coins { get; private set; }
        [field: SerializeField] public long Gems { get; private set; }

        public CoinsForGemsBalance(long coins, long gems)
        {
            Coins = coins;
            Gems = gems;
        }
    }
}