using Sources.Services.Di;

namespace Sources.Data.MonoViews
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