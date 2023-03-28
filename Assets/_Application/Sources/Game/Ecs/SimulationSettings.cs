using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.Quality;

namespace Sources.Game.Ecs
{
    public class SimulationSettings : IService
    {
        private const float Epsilon = 0.001f;
        
        private readonly IQualityAccessService _qualityAccess;
        private readonly SimulationBalance _simulationBalance;

        public SimulationSettings()
        {
            _qualityAccess = DiContainer.Resolve<IQualityAccessService>();
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        private GameQualitySettings QualitySettings => _qualityAccess.GameQualitySettings;

        public float NpcMinActiveRadius => QualitySettings.NpcMinActiveRadius;
        public float BackNpcMinActiveRadius => QualitySettings.BackNpcMinActiveRadius;
        public float NpcMaxActiveRadius => QualitySettings.NpcMinActiveRadius + _simulationBalance.MinDistanceBetweenRoots + Epsilon;
        public float BackNpcMaxActiveRadius => QualitySettings.BackNpcMinActiveRadius + _simulationBalance.MinDistanceBetweenRoots + Epsilon;
        public float CarMinActiveRadius => QualitySettings.NpcMinActiveRadius + _simulationBalance.CarActiveRadiusDelta;
        public float CarMaxActiveRadius => NpcMaxActiveRadius + _simulationBalance.CarActiveRadiusDelta;
        public float BackCarMinActiveRadius => QualitySettings.BackNpcMinActiveRadius + _simulationBalance.CarActiveRadiusDelta;
        public float BackCarMaxActiveRadius => BackNpcMaxActiveRadius + _simulationBalance.CarActiveRadiusDelta;
    }
}