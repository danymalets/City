using Sources.App.Data;
using Sources.ProjectServices.UserServices.Data;
using Sources.Utils.Di;

namespace Sources.ProjectServices.QualityServices
{
    public interface IQualityChangerService : IService
    {
        void SetQuality(QualityType qualityType);
    }
}