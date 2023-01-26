using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Infrastructure.Bootstrap
{
    public class LevelContext : SceneContext, IService
    {
        [SerializeField]
        private SpawnPoint _userSpawnPoint;

        [SerializeField]
        private CameraMonoEntity _cameraMonoEntity;

        [SerializeField]
        private PathSystem _carsPathSystem;

        [SerializeField]
        private PathSystem _npcPathSystem;

        [SerializeField]
        private Fog _fog;
        
        public ISpawnPoint UserSpawnPoint => _userSpawnPoint;

        public CameraMonoEntity CameraMonoEntity => _cameraMonoEntity;
        public IPathSystem CarsPathSystem => _carsPathSystem;
        public IPathSystem NpcPathSystem => _npcPathSystem;
        public Fog Fog => _fog;
    }
}