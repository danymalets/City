using Sources.App.Services.BalanceServices;
using Sources.Utils.Di;

namespace Sources.App.Services.QualityServices
{
    public interface IQualityAccessService : IService
    {
        GameQualitySettings GameQualitySettings { get; }
    }
}