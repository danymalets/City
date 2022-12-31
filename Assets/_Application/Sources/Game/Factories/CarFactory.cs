using Sources.Game.GameObjects.Cars;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Infrastructure.Services;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Factories
{
    public class CarFactory : Factory
    {
        private readonly IPathesAccessService _pathesAccess;

        public CarFactory()
        {
            _pathesAccess = DiContainer.Resolve<IPathesAccessService>();
        }
            
        public Car Create()
        {
            Path path = _pathesAccess.Pathes.GetRandom(path => (path.Distance, path));
            float distanceProgress = Random.Range(0, path.Distance);
            Car car = _poolInstantiator.Instantiate(_assets.CarPrefab);
            car.Setup(path, distanceProgress);
            return car;
        }
    }
}