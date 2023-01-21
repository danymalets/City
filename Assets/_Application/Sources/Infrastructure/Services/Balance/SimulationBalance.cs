using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Services.Balance
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(SimulationBalance), fileName = nameof(SimulationBalance))]
    public class SimulationBalance : ScriptableObject
    {
        [Header("Count")]
        [SerializeField]
        private int _carCount = 20;

        [SerializeField]
        private int _npcCount = 20;

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

        [SerializeField]
        private float _distanceBetweenCars = 0.2f;

        [SerializeField]
        private float _distanceBetweenNpcs = 0.2f;


        public int CarCount => _carCount;

        public int NpcCount => _npcCount;

        public float CarTriggerLength => _carTriggerLength;

        public float NpcTriggerLength => _npcTriggerLength;

        public float MaxBreakingDistance => _maxBreakingDistance;

        public float CarRootToForwardPoint => _carRootToForwardPoint;
        public int PreSolvePathChoiceCount => _preSolvePathChoiceCount;
        public float MinDistanceBetweenRoots => _minDistanceBetweenRoots;

        public float MaxNpcRadius => _maxNpcRadius;

        public float DistanceBetweenCars => _distanceBetweenCars;
        public float DistanceBetweenNpcs => _distanceBetweenNpcs;
    }
}