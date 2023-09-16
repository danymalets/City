using Sources.Utils.Di;

namespace Sources.App.Core.Services.Simulation
{
    public interface ISimulationSettings : IService
    {
        int CarsPer1000SpawnPoints { get; }
        int NpcsPer1000SpawnPoints { get; }
        float NpcsRadius { get; }
        float BackNpcDistance { get; }
        float Delta { get; }
        float CarsRadius { get; }
        float BackCarDistance { get; }
        float SimulationQuadWidth { get; }
    }
}