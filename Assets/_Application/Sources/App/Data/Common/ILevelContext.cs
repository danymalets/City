using _Application.Sources.App.Data.MonoEntities;
using _Application.Sources.App.Data.Pathes;
using _Application.Sources.App.Data.Points;
using _Application.Sources.CommonServices.SceneLoaderServices;
using _Application.Sources.Utils.Di;

namespace _Application.Sources.App.Data.Common
{
    public interface ILevelContext : IService, ISceneContext
    {
        ISpawnPoint UserSpawnPoint { get; }
        ICameraMonoEntity CameraMonoEntity { get; }
        IPathSystem CarsPathSystem { get; }
        IPathSystem NpcPathSystem { get; }
        IFog Fog { get; }
        IIdleCarsSystem IdleCarsSystem { get; }
    }
}