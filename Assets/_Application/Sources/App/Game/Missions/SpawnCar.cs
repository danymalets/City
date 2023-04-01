using Sources.App.Infrastructure.Bootstrap;
using Sources.App.Infrastructure.Services.AssetsManager;

namespace Sources.App.Game.Missions
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