using System.Collections.Generic;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.App.Services.AssetsServices.Monos.MonoEntities.Camera;
using Sources.App.Services.AssetsServices.Monos.MonoEntities.Props;
using Sources.Services.SceneLoaderServices;
using Sources.Utils.Di;

namespace Sources.App.Services.AssetsServices.IdleCarSpawns.Common
{
    public interface ILevelContext : IService, ISceneContext
    {
        IPoint UserSpawnPoint { get; }
        CameraMonoEntity CameraMonoEntity { get; }
        IPathSystem CarsPathSystem { get; }
        IPathSystem NpcPathSystem { get; }
        IFog Fog { get; }
        IIdleCarsSystem IdleCarsSystem { get; }
        IMapCamera MapCamera { get; } 
        IEnumerable<PropsMonoEntity> Props { get; }
    }
}