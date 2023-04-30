using Sources.App.Data.Cars;
using Sources.App.Data.MonoEntities;
using Sources.Utils.Di;

namespace Sources.App.Core.Services
{
    public interface ICarAssetsService : IService
    {
        ICarMonoEntity GetPrefab(CarType carType);
        CarColorData GetRandomPrefab();
    }
}