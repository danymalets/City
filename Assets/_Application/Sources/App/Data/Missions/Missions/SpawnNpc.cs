using Sources.App.Data.Players;
using Sources.App.Data.Points;

namespace Sources.App.Data.Missions.Missions
{
    public class SpawnNpc : SubMissionAction
    {
        public PlayerType PlayerType { get; }
        public IPoint SpawnPoint { get; }

        public SpawnNpc(PlayerType playerType, IPoint spawnPoint)
        {
            PlayerType = playerType;
            SpawnPoint = spawnPoint;
        }

        public override void Start()
        {
            
        }
    }
}