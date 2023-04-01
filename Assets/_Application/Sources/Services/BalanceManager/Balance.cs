using Sources.Di;
using UnityEngine;

namespace Sources.Services.BalanceManager
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(Balance), fileName = nameof(Balance))]
    public class Balance : ScriptableObject, IService
    {
        [SerializeField]
        private CameraBalance _cameraBalance;

        [SerializeField]
        private SimulationBalance _simulationBalance;

        [SerializeField]
        private PlayersBalance _playersBalance;

        [SerializeField]
        private CarsBalance _carsBalance;

        public CameraBalance CameraBalance => _cameraBalance;
        public SimulationBalance SimulationBalance => _simulationBalance;

        public PlayersBalance PlayersBalance => _playersBalance;
        public CarsBalance CarsBalance => _carsBalance;

        [field: SerializeField] public QualityBalance QualityBalance { get; private set; }
        
    }
}