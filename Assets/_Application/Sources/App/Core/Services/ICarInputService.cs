using Sources.Utils.Di;

namespace Sources.App.Core.Services
{
    public interface ICarInputService : IService
    {
        public int Vertical { get; }
        public int Horizontal { get; }
    }
}