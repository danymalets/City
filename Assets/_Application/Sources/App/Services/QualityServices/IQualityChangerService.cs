using Sources.App.Services.UserServices.Data;
using Sources.Utils.Di;

namespace Sources.App.Services.QualityServices
{
    public interface IQualityChangerService : IService
    {
        void SetQuality(QualityType qualityType);
    }
}