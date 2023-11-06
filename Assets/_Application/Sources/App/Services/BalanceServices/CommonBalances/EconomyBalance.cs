using Sources.Services.IapServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.App.Services.BalanceServices.CommonBalances
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(EconomyBalance), fileName = nameof(EconomyBalance))]
    public class EconomyBalance : ScriptableObject
    {
        [FormerlySerializedAs("CoinsForGemsForCoinsExchange1")]
        [field: SerializeField]
        public CoinsForGemsBalance[] CoinsForGemsForCoinsExchange = 
        {
            new(1500, 12),
            new(4000, 48),
            new(12000, 120),
            new(25000, 240),
            new(60000, 490),
        };
        
        [field: SerializeField]
        public IapProductType[] ShopGemProducts =
        {
            IapProductType.Gems40,
            IapProductType.Gems220,
            IapProductType.Gems480,
            IapProductType.Gems1200,
            IapProductType.Gems2100,
        };
    }
}