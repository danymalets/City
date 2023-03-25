using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services.AssetsManager;

namespace Sources.Game.Missions
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