using UnityEngine;

namespace Sources.Infrastructure.Services.Balance
{
    [CreateAssetMenu(menuName = nameof(Balance) + "/" + nameof(SimulationBalance), fileName = nameof(SimulationBalance))]
    public class SimulationBalance : ScriptableObject
    {
        [SerializeField]
        private int _carCount = 20;

        [SerializeField]
        private int _npcCount = 20;

        [SerializeField]
        private float _carTriggerLength = 1.5f;

        [SerializeField]
        private float _npcTriggerLength = 1f;

        public int CarCount => _carCount;

        public int NpcCount => _npcCount;

        public float CarTriggerLength => _carTriggerLength;

        public float NpcTriggerLength => _npcTriggerLength;
    }
}