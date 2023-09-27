using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Components.WorldStatus;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Init
{
    public class SimulationInitSystem : DInitializer
    {
        private Filter _worldStatusFilter;

        protected override void OnInitFilters()
        {
            _worldStatusFilter = _world.Filter<WorldStatusTag>().Build();
        }

        protected override void OnInitialize()
        {
            _worldStatusFilter.GetSingleton()
                .AddForFixedSeconds<ActiveSimulationOn>(2f);
        }
    }
}