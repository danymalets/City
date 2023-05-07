using Sources.App.Data.Cars;
using Sources.App.Data.Points;

namespace Sources.App.Data.Missions.Missions
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