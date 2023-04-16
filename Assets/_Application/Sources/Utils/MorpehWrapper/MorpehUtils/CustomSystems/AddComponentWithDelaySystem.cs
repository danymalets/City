using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.MorpehWrapper.MorpehUtils.Components;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.CustomSystems
{
    public class AddComponentWithDelaySystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<AddComponentAwaiters>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                List<AddComponentAwaiter> awaiters = entity.Get<AddComponentAwaiters>().List;
                List<AddComponentAwaiter> awaitersToDelete = new();

                foreach (AddComponentAwaiter awaiter in awaiters)
                {
                    awaiter.Delay -= deltaTime;

                    if (awaiter.Delay <= 0)
                    {
                        awaiter.ComponentWrapper.SetToEntity(entity);
                        awaitersToDelete.Add(awaiter);
                    }
                }

                foreach (AddComponentAwaiter awaiter in awaitersToDelete)
                {
                    awaiters.Remove(awaiter);
                }
                
                // if (awaiters.Count == 0)
                //     entity.RemoveList<AddComponentAwaiters, AddComponentAwaiter>();
            }
        }
    }
}