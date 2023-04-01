using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Balance
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(SimulationBalance), fileName = nameof(SimulationBalance))]
    public class SimulationBalance : ScriptableObject
    {
        [Header("Count")]
        [SerializeField]
        private int _carsCountPer1000SpawnPoints = 20;

        [SerializeField]
        private int _npcCountPer1000SpawnPoints = 20;

        [Header("Triggers")]
        [SerializeField]
        private float _carTriggerLength = 1.5f;

        [SerializeField]
        private float _npcTriggerLength = 1f;

        [Header("Path System")]
        [SerializeField]
        private float _maxBreakingDistance = 1.5f;

        [SerializeField]
        private float _carRootToForwardPoint = 0.4f;

        [field: SerializeField]
        public float MinDistanceBetweenRoots { get; private set; } = 4;

        [FormerlySerializedAs("_preSolvePathChoice")]
        [SerializeField]
        private int _preSolvePathChoiceCount = 5;

        [FormerlySerializedAs("_maxPlayerRadius")]
        [SerializeField]
        private float _maxNpcRadius = 0.4f;

        [FormerlySerializedAs("_distanceBetweenCars")]
        [SerializeField]
        private float _carDistanceAfterBreak = 0.2f;

        [FormerlySerializedAs("_distanceBetweenNpcs")]
        [SerializeField]
        private float _npcDistanceAfterBreak = 0.2f;

        [SerializeField]
        private float _crosswalkWidth = 3f;
        
        [field: Header("Generation")]
        [field: SerializeField]
        public float CarActiveRadiusDelta { get; private set; } = 4f;

        public int CarsCountPer1000SpawnPoints => _carsCountPer1000SpawnPoints;

        public int NpcCountPer1000SpawnPoints => _npcCountPer1000SpawnPoints;

        public float CarTriggerLength => _carTriggerLength;

        public float NpcTriggerLength => _npcTriggerLength;

        public float MaxBreakingDistance => _maxBreakingDistance;

        public float CarRootToForwardPoint => _carRootToForwardPoint;
        public int PreSolvePathChoiceCount => _preSolvePathChoiceCount;

        public float MaxNpcRadius => _maxNpcRadius;

        public float CarDistanceAfterBreak => _carDistanceAfterBreak;
        public float NpcDistanceAfterBreak => _npcDistanceAfterBreak;

        public float CrosswalkWidth => _crosswalkWidth;
    }
}