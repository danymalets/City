using _Application.Sources.Data;
using Sources.Di;

namespace Sources.Services.Quality
{
    public interface IQualityChangerService : IService
    {
        void SetQuality(QualityType qualityType);
    }
}