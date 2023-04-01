using Sources.Services.BalanceManager;
using Sources.Services.Di;

namespace Sources.Services.Quality
{
    public interface IQualityAccessService : IService
    {
        GameQualitySettings GameQualitySettings { get; }
    }
}