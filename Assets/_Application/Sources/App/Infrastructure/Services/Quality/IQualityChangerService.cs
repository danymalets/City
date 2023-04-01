using Sources.App.Infrastructure.Services.Balance;

namespace Sources.App.Infrastructure.Services.Quality
{
    public interface IQualityChangerService : IService
    {
        void SetQuality(QualityType qualityType);
    }
}