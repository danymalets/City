using Sources.App.Game.Ecs.MonoEntities;
using Sources.App.Game.GameObjects.RoadSystem;
using Sources.App.Infrastructure.Bootstrap.IdleCarSpawns;
using Sources.Di;
using UnityEngine;

namespace Sources.App.Infrastructure.Bootstrap
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

        [SerializeField]
        private IdleCarsSystem _idleCarsSystem;

        public ISpawnPoint UserSpawnPoint => _userSpawnPoint;

        public CameraMonoEntity CameraMonoEntity => _cameraMonoEntity;
        public IPathSystem CarsPathSystem => _carsPathSystem;
        public IPathSystem NpcPathSystem => _npcPathSystem;
        public Fog Fog => _fog;
        public IdleCarsSystem IdleCarsSystem => _idleCarsSystem;
    }
}