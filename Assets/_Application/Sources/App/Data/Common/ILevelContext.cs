using Sources.App.Data.MonoEntities;
using Sources.App.Data.Pathes;
using Sources.App.Data.Points;
using Sources.CommonServices.SceneLoaderServices;
using Sources.Utils.Di;

namespace Sources.App.Data.Common
{
    public interface ILevelContext : IService, ISceneContext
    {
        ISpawnPoint UserSpawnPoint { get; }
        ICameraMonoEntity CameraMonoEntity { get; }
        IPathSystem CarsPathSystem { get; }
        IPathSystem NpcPathSystem { get; }
        IFog Fog { get; }
        IIdleCarsSystem IdleCarsSystem { get; }
        IMapCamera MapCamera { get; }
    }
}