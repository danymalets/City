using Sources.App.Game.Services;
using Sources.Data.Common;
using Sources.Services.Di;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;

namespace Sources.App.Game.Ecs.Systems.Init
{
    public class FogInitSystem : DInitializer
    {
        private readonly ILevelContext _levelContext;
        private readonly SimulationSettings _simulationSettings;

        public FogInitSystem()
        {
            _levelContext = DiContainer.Resolve<ILevelContext>();
            _simulationSettings = DiContainer.Resolve<SimulationSettings>();
        }

        protected override void OnInitialize()
        {
            _levelContext.Fog.SetRadius(_simulationSettings.NpcMinActiveRadius - 0.5f);
        }
    }
}