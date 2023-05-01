using Sources.Services.BalanceServices;
using Sources.Utils.Di;

namespace Sources.Services.QualityServices
{
    public interface IQualityAccessService : IService
    {
        GameQualitySettings GameQualitySettings { get; }
    }
}