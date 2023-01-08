using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils;
using Sources.Game.GameObjects.RoadSystem;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap
{
    public class LevelContextService : SceneContext, ILevelContextService
    {
        [SerializeField]
        public SpawnPoint _userSpawnPoint;

        [SerializeField]
        private CameraMonoEntity _cameraMonoEntity;

        [SerializeField]
        private PathSystem _pathSystem;

        public ISpawnPoint UserSpawnPoint => _userSpawnPoint;

        public CameraMonoEntity CameraMonoEntity => _cameraMonoEntity;
        public PathSystem PathSystem => _pathSystem;
    }
}