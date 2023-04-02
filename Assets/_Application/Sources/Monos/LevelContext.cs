using Sources.Data.MonoViews;
using Sources.Monos.Bootstrap;
using Sources.Monos.Bootstrap.IdleCarSpawns;
using Sources.Monos.MonoEntities;
using Sources.Monos.RoadSystem;
using UnityEngine;

namespace Sources.Monos
{
    public class LevelContext : SceneContext, ILevelContext
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

        public ICameraMonoEntity CameraMonoEntity => _cameraMonoEntity;
        public IPathSystem CarsPathSystem => _carsPathSystem;
        public IPathSystem NpcPathSystem => _npcPathSystem;
        public IFog Fog => _fog;
        public IIdleCarsSystem IdleCarsSystem => _idleCarsSystem;
    }
}