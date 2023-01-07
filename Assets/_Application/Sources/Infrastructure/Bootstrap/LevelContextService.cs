using Sources.Game.Ecs.Utils;
using UnityEngine;

namespace Sources.Infrastructure.Bootstrap
{
    public class LevelContextService : SceneContext, ILevelContextService
    {
        [SerializeField]
        public SpawnPoint _userSpawnPoint;

        [SerializeField]
        private MonoEntity _cameraMonoEntity;

        [SerializeField]
        private MonoEntity _pathSystemEntity;


        public ISpawnPoint UserSpawnPoint => _userSpawnPoint;

        public MonoEntity CameraMonoEntity => _cameraMonoEntity;
        public MonoEntity PathSystemEntity => _pathSystemEntity;
    }
}