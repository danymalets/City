using Sources.Game.Ecs.Utils;
using Sources.Infrastructure.Services;

namespace Sources.Infrastructure.Bootstrap
{
    public interface ILevelContextService : IService
    {
        ISpawnPoint UserSpawnPoint { get; }
        MonoEntity CameraMonoEntity { get; }
    }
}