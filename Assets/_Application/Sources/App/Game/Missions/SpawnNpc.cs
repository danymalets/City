using Sources.App.Infrastructure.Bootstrap;
using Sources.App.Infrastructure.Services.AssetsManager;

namespace Sources.App.Game.Missions
{
    public class SpawnNpc : SubMissionAction
    {
        public PlayerType PlayerType { get; }
        public ISpawnPoint SpawnPoint { get; }

        public SpawnNpc(PlayerType playerType, ISpawnPoint spawnPoint)
        {
            PlayerType = playerType;
            SpawnPoint = spawnPoint;
        }

        public override void Start()
        {
            
        }
    }
}