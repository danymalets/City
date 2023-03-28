using Sources.Infrastructure.Services.Balance;

namespace Sources.Infrastructure.Services.Quality
{
    public interface IQualityChangerService : IService
    {
        void SetQuality(QualityType qualityType);
    }
}