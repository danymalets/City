using Sources.App.Data.Points;

namespace Sources.App.Core.Missions
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