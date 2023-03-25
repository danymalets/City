using Sources.Infrastructure.Bootstrap;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Game.Missions
{
    public class Mission1Context : MonoBehaviour, IMission1Context
    {
        [Header("House Scene")]
        [SerializeField]
        private CameraPoint _houseCameraPoint;
        
        [SerializeField]
        private SpawnPoint _dadSpawnPoint;
        
        [SerializeField]
        private SpawnPoint _mumSpawnPoint;
        
        [Header("Uncle Scene")]
        [SerializeField]
        private CameraPoint _uncleHouseCameraPoint;
        
        [SerializeField]
        private SpawnPoint _uncleSpawnPoint; 
        
        [SerializeField]
        private SpawnPoint _taxiSpawnPoint;

        public ICameraPoint HouseCameraPoint => _houseCameraPoint;
        public ISpawnPoint DadSpawnPoint => _dadSpawnPoint;
        public ISpawnPoint MumSpawnPoint => _mumSpawnPoint;
        public ISpawnPoint UncleSpawnPoint => _uncleSpawnPoint;
        public ISpawnPoint TaxiSpawnPoint => _taxiSpawnPoint;
        public ISpawnPoint SedanSpawnPoint { get; set; }
        public ICameraPoint UncleCameraPoint => _uncleHouseCameraPoint;
    }
}