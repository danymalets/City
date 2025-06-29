using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Points;

namespace Sources.App.Services.AssetsServices.Common.Missions
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