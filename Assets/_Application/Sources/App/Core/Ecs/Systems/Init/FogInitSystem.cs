using Sources.App.Core.Services;
using Sources.App.Data.Common;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Init
{
    public class FogInitSystem : DInitializer
    {
        private readonly ILevelContext _levelContext;
        private readonly ISimulationSettings _simulationSettings;
        
        public FogInitSystem()
        {
            _levelContext = DiContainer.Resolve<ILevelContext>();
            _simulationSettings = DiContainer.Resolve<ISimulationSettings>();
        }

        protected override void OnInitialize()
        {
            _levelContext.Fog.SetRadius(_simulationSettings.NpcsRadius - 0.5f);
        }
    }
}