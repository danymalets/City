using Sources.Balance;
using Sources.Di;

namespace Sources.Services.Quality
{
    public interface IQualityAccessService : IService
    {
        GameQualitySettings GameQualitySettings { get; }
    }
}