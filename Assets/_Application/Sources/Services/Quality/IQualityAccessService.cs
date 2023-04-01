using Sources.Di;
using Sources.Services.BalanceManager;

namespace Sources.Services.Quality
{
    public interface IQualityAccessService : IService
    {
        GameQualitySettings GameQualitySettings { get; }
    }
}