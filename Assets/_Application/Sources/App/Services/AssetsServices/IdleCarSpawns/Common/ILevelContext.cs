using System.Collections.Generic;
using Sources.App.Data.MonoEntities;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.Services.SceneLoaderServices;
using Sources.Utils.Di;

namespace Sources.App.Data.Common
{
    public interface ILevelContext : IService, ISceneContext
    {
        IPoint UserSpawnPoint { get; }
        ICameraMonoEntity CameraMonoEntity { get; }
        IPathSystem CarsPathSystem { get; }
        IPathSystem NpcPathSystem { get; }
        IFog Fog { get; }
        IIdleCarsSystem IdleCarsSystem { get; }
        IMapCamera MapCamera { get; } 
        IEnumerable<IPropsMonoEntity> Props { get; }
    }
}