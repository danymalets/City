using Sources.Data.Points;

namespace Sources.Data.Missions
{
    public interface IMission1Context
    {
        ICameraPoint HouseCameraPoint { get; }
        ISpawnPoint DadSpawnPoint { get; }
        ISpawnPoint MumSpawnPoint { get; }
        ISpawnPoint UncleSpawnPoint { get; }
        ISpawnPoint TaxiSpawnPoint { get; }
        ISpawnPoint SedanSpawnPoint { get; set; }
        ICameraPoint UncleCameraPoint { get; }
    }
}