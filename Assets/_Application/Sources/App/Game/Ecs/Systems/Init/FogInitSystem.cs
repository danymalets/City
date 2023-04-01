using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Infrastructure.Bootstrap;
using Sources.App.Infrastructure.Services;

namespace Sources.App.Game.Ecs.Systems.Init
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