using Sources.App.Data.Constants;
using Sources.ProjectServices.BalanceServices;
using Sources.ProjectServices.QualityServices;
using Sources.Utils.Di;

namespace Sources.App.Core.Services
{
    public class SimulationSettings : ISimulationSettings
    {
        private const float Epsilon = 0.001f;
        
        private readonly IQualityAccessService _qualityAccess;
        private readonly SimulationBalance _simulationBalance;

        public SimulationSettings()
        {
            _qualityAccess = DiContainer.Resolve<IQualityAccessService>();
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        public int CarsPer1000SpawnPoints => QualitySettings.CarsPer1000SpawnPoints;
        public int NpcsPer1000SpawnPoints => QualitySettings.NpcsPer1000SpawnPoints;
        public float NpcsRadius => QualitySettings.NpcRadius;
        public float BackNpcDistance => QualitySettings.BackDistance;
        public float Delta => _simulationBalance.MinDistanceBetweenRoots + Epsilon;
        public float CarsRadius => QualitySettings.NpcRadius + _simulationBalance.CarsDelta;
        public float CarsMaxRadius => CarsRadius + Delta;
        public float BackCarDistance => QualitySettings.BackDistance + _simulationBalance.CarsDelta;
        public float SimulationQuadWidth => CarsMaxRadius / Consts.SimulationOneSideQuadCount;

        private GameQualitySettings QualitySettings => _qualityAccess.GameQualitySettings;
    }
}