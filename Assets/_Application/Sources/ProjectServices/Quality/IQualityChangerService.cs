using Sources.Data;
using Sources.Services.Di;

namespace Sources.Services.Quality
{
    public interface IQualityChangerService : IService
    {
        void SetQuality(QualityType qualityType);
    }
}