using Sources.App.Services.BalanceServices;
using Sources.Utils.Di;

namespace Sources.App.Core.Services.Quality
{
    public interface IQualityAccessService : IService
    {
        GameQualitySettings GameQualitySettings { get; }
    }
}