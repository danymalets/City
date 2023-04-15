using _Application.Sources.App.Data.Points;

namespace _Application.Sources.App.Core.Missions
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