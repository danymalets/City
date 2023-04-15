using Sources.Data.MonoEntities;
using Sources.Data.Pathes;
using Sources.Data.Points;
using Sources.Services.Di;
using Sources.Services.SceneLoader;

namespace Sources.Data.Common
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