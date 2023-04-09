using Sources.Services.Di;

namespace Sources.App.Game.Services
{
    public interface ICarInputService : IService
    {
        public int Vertical { get; }
        public int Horizontal { get; }
    }
}