using Sources.App.Services.AssetsServices.Common.Monos.Players;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points;

namespace Sources.App.Services.BalanceServices.Missions
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