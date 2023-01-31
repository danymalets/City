using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Services.Balance
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

        [SerializeField]
        private float _minDistanceBetweenRoots = 1.5f;

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
        
        [Header("Generation")]
        [SerializeField]
        private float _minActiveRadius = 20;
        
        [SerializeField]
        private float _maxActiveRadius = 31;

        [SerializeField]
        private float _carActiveRadiusDelta = 3.5f;
        
        public int CarsCountPer1000SpawnPoints => _carsCountPer1000SpawnPoints;

        public int NpcCountPer1000SpawnPoints => _npcCountPer1000SpawnPoints;

        public float CarTriggerLength => _carTriggerLength;

        public float NpcTriggerLength => _npcTriggerLength;

        public float MaxBreakingDistance => _maxBreakingDistance;

        public float CarRootToForwardPoint => _carRootToForwardPoint;
        public int PreSolvePathChoiceCount => _preSolvePathChoiceCount;
        public float MinDistanceBetweenRoots => _minDistanceBetweenRoots;

        public float MaxNpcRadius => _maxNpcRadius;

        public float CarDistanceAfterBreak => _carDistanceAfterBreak;
        public float NpcDistanceAfterBreak => _npcDistanceAfterBreak;

        public float CrosswalkWidth => _crosswalkWidth;

        public float MinActiveRadius => _minActiveRadius;

        public float MaxActiveRadius => _maxActiveRadius;

        public float CarActiveRadiusDelta => _carActiveRadiusDelta;
    }
}