using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.BalanceServices
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(Balance), fileName = nameof(Balance))]
    public class Balance : ScriptableObject, IService
    {
        [field: SerializeField] public QualityBalance QualityBalance { get; private set; }
        [field: SerializeField] public EconomyBalance EconomyBalance { get; private set; }
    }
}