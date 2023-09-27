using Scellecs.Morpeh;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.CustomSystems
{
    public class OneFrameCleanupSystem<TComponent> : DUpdateSystem where TComponent : struct, IComponent
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<TComponent>().Build();
        }
        
        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                entity.Remove<TComponent>();
            }
        }
    }
}