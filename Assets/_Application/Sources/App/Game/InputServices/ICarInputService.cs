using Sources.Di;

namespace Sources.App.Game.InputServices
{
    public interface ICarInputService : IService
    {
        public int Vertical { get; }
        public int Horizontal { get; }
    }
}