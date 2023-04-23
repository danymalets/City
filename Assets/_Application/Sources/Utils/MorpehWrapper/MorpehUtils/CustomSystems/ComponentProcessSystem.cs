using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.MorpehWrapper.MorpehUtils.Components;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.CustomSystems
{
    public class ComponentProcessSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<ComponentProcessAwaiters>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                List<ComponentProcessAwaiter> awaiters = entity.Get<ComponentProcessAwaiters>().List;
                List<ComponentProcessAwaiter> awaitersToDelete = new();

                foreach (ComponentProcessAwaiter awaiter in awaiters)
                {
                    awaiter.Delay -= deltaTime;

                    if (awaiter.Delay <= 0)
                    {
                        awaiter.ComponentWrapper.ProcessWithEntity(entity);
                        awaitersToDelete.Add(awaiter);
                    }
                }

                foreach (ComponentProcessAwaiter awaiter in awaitersToDelete)
                {
                    awaiters.Remove(awaiter);
                }
            }
        }
    }
}