

using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.MorpehWrapper.MorpehUtils.Components;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.CustomSystems
{
    public class CollisionsClearSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<Collisions>();
        }
        
        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                Collisions collisions = entity.Get<Collisions>();
                collisions.List.Clear();
            }
        }
    }
}