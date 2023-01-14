using Sources.Infrastructure.Services;

namespace Sources.Game.InputServices
{
    public interface ICarInputService : IService
    {
        public int Vertical { get; }
        public int Horizontal { get; }
    }
}