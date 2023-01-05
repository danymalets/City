using Sources.Infrastructure.Services;

namespace Sources.Game.InputServices
{
    public interface IInputService : IService
    {
        public int Vertical { get; }
        public int Horizontal { get; }
    }
}