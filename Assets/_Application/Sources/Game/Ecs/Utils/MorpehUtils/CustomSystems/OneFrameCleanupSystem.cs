using Scellecs.Morpeh;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;

namespace Sources.Game.Ecs.Utils.MorpehUtils.CustomSystems
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