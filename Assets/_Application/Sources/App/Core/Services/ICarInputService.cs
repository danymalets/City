using _Application.Sources.Utils.Di;

namespace _Application.Sources.App.Core.Services
{
    public interface ICarInputService : IService
    {
        public int Vertical { get; }
        public int Horizontal { get; }
    }
}