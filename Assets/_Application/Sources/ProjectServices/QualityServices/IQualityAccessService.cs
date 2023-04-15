using _Application.Sources.Utils.Di;
using Sources.ProjectServices.BalanceServices;

namespace Sources.ProjectServices.QualityServices
{
    public interface IQualityAccessService : IService
    {
        GameQualitySettings GameQualitySettings { get; }
    }
}