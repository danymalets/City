using Sources.App.Data.Points;

namespace Sources.App.Data.Missions
{
    public interface IMission1Context
    {
        ICameraPoint HouseCameraPoint { get; }
        IPoint DadSpawnPoint { get; }
        IPoint MumSpawnPoint { get; }
        IPoint UncleSpawnPoint { get; }
        IPoint TaxiSpawnPoint { get; }
        IPoint SedanSpawnPoint { get; set; }
        ICameraPoint UncleCameraPoint { get; }
    }
}