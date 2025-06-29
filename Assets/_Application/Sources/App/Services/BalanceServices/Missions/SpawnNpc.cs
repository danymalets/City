using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Points;
using Sources.App.Services.AssetsServices.Common.Players.PlayersData;

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