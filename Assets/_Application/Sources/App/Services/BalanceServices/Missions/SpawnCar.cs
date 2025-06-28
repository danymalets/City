using Sources.App.Services.AssetsServices.Common.Monos.Cars;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points;

namespace Sources.App.Services.BalanceServices.Missions
{
    public class SpawnCar : SubMissionAction
    {
        public CarType CarType { get; }
        public IPoint SpawnPoint { get; }

        public SpawnCar(CarType carType, IPoint spawnPoint)
        {
            CarType = carType;
            SpawnPoint = spawnPoint;
        }

        public override void Start()
        {
            
        }
    }
}