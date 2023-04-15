using Sources.App.Data;
using Sources.ProjectServices.UserService.Data;
using Sources.Utils.Di;

namespace Sources.ProjectServices.QualityServices
{
    public interface IQualityChangerService : IService
    {
        void SetQuality(QualityType qualityType);
    }
}