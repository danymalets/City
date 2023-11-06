using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.Utils.Di;

namespace Sources.App.Core.Services.Quality
{
    public interface IQualityAccessService : IService
    {
        GameQualitySettings GameQualitySettings { get; }
    }
}