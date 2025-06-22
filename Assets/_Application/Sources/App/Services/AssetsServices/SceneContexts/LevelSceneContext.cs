using System.Collections.Generic;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.App.Services.AssetsServices.Common.IdleCarSpawns;
using Sources.App.Services.AssetsServices.Common.IdleCarSpawns.Common;
using Sources.App.Services.AssetsServices.Common.Monos.Bootstrap;
using Sources.App.Services.AssetsServices.Common.Monos.MonoEntities.Camera;
using Sources.App.Services.AssetsServices.Common.Monos.MonoEntities.Props;
using Sources.App.Services.AssetsServices.Common.Monos.Points;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem;
using Sources.Services.SceneLoaderServices;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.SceneContexts
{
    public partial class LevelSceneContext : SceneContext, ILevelContext
    {
        [SerializeField]
        private MonoPoint _userSpawnPoint;

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

        [SerializeField]
        private MapCamera _mapCamera;

        [SerializeField]
        private PropsMonoEntity[] _props;
        
        public IPoint UserSpawnPoint => _userSpawnPoint;
        public CameraMonoEntity CameraMonoEntity => _cameraMonoEntity;
        public IPathSystem CarsPathSystem => _carsPathSystem;
        public IPathSystem NpcPathSystem => _npcPathSystem;
        public IFog Fog => _fog;
        public IIdleCarsSystem IdleCarsSystem => _idleCarsSystem;
        public IMapCamera MapCamera => _mapCamera;
        public IEnumerable<PropsMonoEntity> Props => _props;
    }
}