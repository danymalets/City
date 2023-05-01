using Sources.Services.UserServices.Data;
using Sources.Utils.Di;

namespace Sources.Services.QualityServices
{
    public interface IQualityChangerService : IService
    {
        void SetQuality(QualityType qualityType);
    }
}