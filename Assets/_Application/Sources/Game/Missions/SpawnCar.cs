using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services.Balance;

namespace Sources.Game.Missions
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