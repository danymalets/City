using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public class OneFrameListCleanupSystem<TList, TValue> : DUpdateSystem where TList : struct, IListOf<TValue>
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<TList>();
        }
        
        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                TList list = entity.Get<TList>();
                list.List.Clear();
            }
        }
    }
}