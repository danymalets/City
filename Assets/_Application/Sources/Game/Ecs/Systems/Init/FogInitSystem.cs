using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;

namespace Sources.Game.Ecs.Systems.Init
{
    public class FogInitSystem : DInitializer
    {
        private readonly LevelContext _levelContext;
        private readonly SimulationSettings _simulationSettings;

        public FogInitSystem()
        {
            _levelContext = DiContainer.Resolve<LevelContext>();
            _simulationSettings = DiContainer.Resolve<SimulationSettings>();
        }

        protected override void OnInitialize()
        {
            _levelContext.Fog.SetRadius(_simulationSettings.NpcMinActiveRadius - 0.5f);
        }
    }
}