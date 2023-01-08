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
        public SpawnPoint _userSpawnPoint;

        [SerializeField]
        private CameraMonoEntity _cameraMonoEntity;

        [FormerlySerializedAs("_pathSystem")]
        [SerializeField]
        private PathSystem _carsPathSystem;

        [SerializeField]
        private PathSystem _npcPathSystem;
        
        public ISpawnPoint UserSpawnPoint => _userSpawnPoint;

        public CameraMonoEntity CameraMonoEntity => _cameraMonoEntity;
        public IPathSystem CarsPathSystem => _carsPathSystem;
        public PathSystem NpcPathSystem => _npcPathSystem;
    }
}