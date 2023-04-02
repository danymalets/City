using Sources.Data;
using Sources.Data.MonoViews;

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