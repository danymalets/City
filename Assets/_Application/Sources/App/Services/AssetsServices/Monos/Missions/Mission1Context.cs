using Sources.App.Data.Missions;
using Sources.App.Data.Points;
using Sources.App.Services.AssetsServices.Monos.Points;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Monos.Missions
{
    public class Mission1Context : MonoBehaviour, IMission1Context
    {
        [Header("House Scene")]
        [SerializeField]
        private CameraPoint _houseCameraPoint;
        
        [SerializeField]
        private MonoPoint _dadSpawnPoint;
        
        [SerializeField]
        private MonoPoint _mumSpawnPoint;
        
        [Header("Uncle Scene")]
        [SerializeField]
        private CameraPoint _uncleHouseCameraPoint;
        
        [SerializeField]
        private MonoPoint _uncleSpawnPoint; 
        
        [SerializeField]
        private MonoPoint _taxiSpawnPoint;

        public ICameraPoint HouseCameraPoint => _houseCameraPoint;
        public IPoint DadSpawnPoint => _dadSpawnPoint;
        public IPoint MumSpawnPoint => _mumSpawnPoint;
        public IPoint UncleSpawnPoint => _uncleSpawnPoint;
        public IPoint TaxiSpawnPoint => _taxiSpawnPoint;
        public IPoint SedanSpawnPoint { get; set; }
        public ICameraPoint UncleCameraPoint => _uncleHouseCameraPoint;
    }
}