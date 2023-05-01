using Sources.App.Data.Common;
using Sources.App.Data.MonoEntities;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.CommonServices.SceneLoaderServices;
using Sources.ProjectServices.AssetsServices.Monos.Bootstrap;
using Sources.ProjectServices.AssetsServices.Monos.MonoEntities;
using Sources.ProjectServices.AssetsServices.Monos.Points;
using Sources.ProjectServices.AssetsServices.Monos.RoadSystem;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.ProjectServices.AssetsServices.IdleCarSpawns
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

        [FormerlySerializedAs("_map")]
        [SerializeField]
        private MapCamera _mapCamera;

        public ISpawnPoint UserSpawnPoint => _userSpawnPoint;
        public ICameraMonoEntity CameraMonoEntity => _cameraMonoEntity;
        public IPathSystem CarsPathSystem => _carsPathSystem;
        public IPathSystem NpcPathSystem => _npcPathSystem;
        public IFog Fog => _fog;
        public IIdleCarsSystem IdleCarsSystem => _idleCarsSystem;
        public IMapCamera MapCamera => _mapCamera;
    }
}