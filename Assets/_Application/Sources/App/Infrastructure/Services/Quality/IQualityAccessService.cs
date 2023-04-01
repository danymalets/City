using Sources.App.Infrastructure.Services.Balance;

namespace Sources.App.Infrastructure.Services.Quality
{
    public interface IQualityAccessService : IService
    {
        GameQualitySettings GameQualitySettings { get; }
    }
}