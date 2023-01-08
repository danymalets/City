using Sources.Game.Ecs.MonoEntities;
using Sources.Game.Ecs.Utils;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Infrastructure.Services;

namespace Sources.Infrastructure.Bootstrap
{
    public interface ILevelContextService : IService
    {
        ISpawnPoint UserSpawnPoint { get; }
        CameraMonoEntity CameraMonoEntity { get; }
        PathSystem PathSystem { get; }
    }
}