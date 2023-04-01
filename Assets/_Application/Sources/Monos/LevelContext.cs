using Sources.Monos.Bootstrap;
using Sources.Monos.Bootstrap.IdleCarSpawns;
using Sources.Monos.MonoEntities;
using Sources.Monos.RoadSystem;
using Sources.Services.Di;
using UnityEngine;

namespace Sources.Monos
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