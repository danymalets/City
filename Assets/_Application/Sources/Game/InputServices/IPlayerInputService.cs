using Sources.Infrastructure.Services;

namespace Sources.Game.InputServices
{
    public interface IPlayerInputService : IService
    {
        float Vertical { get; }
        float Horizontal { get; }
    }
}