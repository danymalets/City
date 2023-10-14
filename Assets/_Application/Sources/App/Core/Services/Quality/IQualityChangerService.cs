using Sources.App.Services.UserServices.Users.PreferencesData;
using Sources.Utils.Di;

namespace Sources.App.Core.Services.Quality
{
    public interface IQualityChangerService : IService
    {
        void SetQuality(QualityType qualityType);
    }
}