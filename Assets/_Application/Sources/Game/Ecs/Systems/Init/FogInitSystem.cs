using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;

namespace Sources.Game.Ecs.Systems.Init
{
    public class FogInitSystem : DInitializer
    {
        private readonly LevelContext _levelContext;
        private readonly SimulationBalance _simulationBalance;

        public FogInitSystem()
        {
            _levelContext = DiContainer.Resolve<LevelContext>();
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnInitialize()
        {
            _levelContext.Fog.SetRadius(_simulationBalance.NpcMinActiveRadius - 0.5f);
        }
    }
}