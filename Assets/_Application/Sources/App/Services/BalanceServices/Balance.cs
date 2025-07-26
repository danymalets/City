using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.BalanceServices
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(Balance), fileName = nameof(Balance))]
    public class Balance : ScriptableObject, IService
    {
        [field: SerializeField] public CameraBalance CameraBalance { get; private set; }
        [field: SerializeField] public SimulationBalance SimulationBalance { get; private set; }

        [field: SerializeField] public QualityBalance QualityBalance { get; private set; }
        [field: SerializeField] public EconomyBalance EconomyBalance { get; private set; }
        [field: SerializeField] public CommonBalance CommonBalance { get; private set; }
    }
}