using Sources.ProjectServices.BalanceServices;
using Sources.Utils.Di;

namespace Sources.ProjectServices.QualityServices
{
    public interface IQualityAccessService : IService
    {
        GameQualitySettings GameQualitySettings { get; }
    }
}