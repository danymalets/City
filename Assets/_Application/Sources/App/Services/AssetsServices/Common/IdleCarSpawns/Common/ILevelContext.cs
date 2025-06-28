using System.Collections.Generic;
using Sources.App.Services.AssetsServices.Common.Monos.MonoEntities.Camera;
using Sources.App.Services.AssetsServices.Common.Monos.MonoEntities.Props;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Pathes;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points;
using Sources.Services.SceneLoaderServices;
using Sources.Utils.Di;

namespace Sources.App.Services.AssetsServices.Common.IdleCarSpawns.Common
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