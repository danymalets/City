using Sources.App.Data;
using Sources.App.Data.Points;

namespace Sources.App.Core.Missions
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