using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Services.BalanceServices
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(Balance), fileName = nameof(Balance))]
    public class Balance : ScriptableObject, IService
    {
        [field: SerializeField] public CameraBalance CameraBalance { get; private set; }
        [field: SerializeField] public SimulationBalance SimulationBalance { get; private set; }

        [field: SerializeField] public PlayersBalance PlayersBalance { get; private set; }
        [field: SerializeField] public CarsBalance CarsBalance { get; private set; }

        [field: SerializeField] public QualityBalance QualityBalance { get; private set; }
        [field: SerializeField] public CommonBalance CommonBalance { get; private set; }
    }
}