using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.Utils.MorpehWrapper.MorpehUtils.CustomSystems
{
    public class OneFrameCleanupSystem<TComponent> : DUpdateSystem where TComponent : struct, IComponent
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<TComponent>();
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