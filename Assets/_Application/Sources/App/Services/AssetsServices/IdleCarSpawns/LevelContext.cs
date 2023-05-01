using Sources.App.Data.Common;
using Sources.App.Data.MonoEntities;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.App.Services.AssetsServices.Monos.Bootstrap;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.App.Services.AssetsServices.Monos.Points;
using Sources.App.Services.AssetsServices.Monos.RoadSystem;
using Sources.Services.SceneLoaderServices;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.App.Services.AssetsServices.IdleCarSpawns
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