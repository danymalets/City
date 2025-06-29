using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Points;

namespace Sources.App.Services.BalanceServices.Missions
{
    public class DialogueCamera
    {
        public ICameraPoint SpawnPoint { get; }

        public DialogueCamera(ICameraPoint spawnPoint)
        {
            SpawnPoint = spawnPoint;
        }
    }
}