using Sources.App.Data.Cars;
using Sources.App.Data.Points;

namespace Sources.App.Core.Missions
{
    public class SpawnCar : SubMissionAction
    {
        public CarType CarType { get; }
        public ISpawnPoint SpawnPoint { get; }

        public SpawnCar(CarType carType, ISpawnPoint spawnPoint)
        {
            CarType = carType;
            SpawnPoint = spawnPoint;
        }

        public override void Start()
        {
            
        }
    }
}