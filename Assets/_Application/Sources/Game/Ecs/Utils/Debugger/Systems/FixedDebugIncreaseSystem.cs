using Scellecs.Morpeh;
using Sources.Game.Ecs.Utils.Debugger.Components;
using Sources.Game.Ecs.Utils.MorpehWrapper;

namespace Sources.Game.Ecs.Utils.Debugger.Systems
{
    public class FixedDebugIncreaseSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<SystemsDebugComponent>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                ref SystemsDebugComponent systemsDebugData = ref entity.Get<SystemsDebugComponent>();

                systemsDebugData.Data.IncreaseFixedIndex();
            }
        }
    }
}