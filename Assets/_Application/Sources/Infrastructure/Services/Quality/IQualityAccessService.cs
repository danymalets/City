using Sources.Infrastructure.Services.Balance;

namespace Sources.Infrastructure.Services.Quality
{
    public interface IQualityAccessService : IService
    {
        GameQualitySettings GameQualitySettings { get; }
    }
}