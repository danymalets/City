using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;

namespace Sources.App.DMorpeh.MorpehUtils.CustomSystems
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