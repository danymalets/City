using _Application.Sources.App.Data;
using _Application.Sources.Utils.Di;

namespace Sources.ProjectServices.QualityServices
{
    public interface IQualityChangerService : IService
    {
        void SetQuality(QualityType qualityType);
    }
}