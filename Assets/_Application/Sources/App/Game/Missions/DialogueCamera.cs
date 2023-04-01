namespace Sources.App.Game.Missions
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