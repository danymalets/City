using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.MorpehWrapper.MorpehUtils.Components;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.CustomSystems
{
    public abstract class ComponentProcessSystem<TAwaiter> : DUpdateSystem
        where TAwaiter : struct, IAwaiters, IComponent
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<TAwaiter>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity entity in _filter)
            {
                List<ComponentAwaiter> awaiters = entity.Get<TAwaiter>().List;
                List<ComponentAwaiter> awaitersToDelete = new();

                foreach (ComponentAwaiter awaiter in awaiters)
                {
                    awaiter.Delay -= deltaTime;

                    if (awaiter.Delay <= 0)
                    {
                        awaiter.ComponentWrapper.ProcessEntity(entity);
                        awaitersToDelete.Add(awaiter);
                    }
                }

                foreach (ComponentAwaiter awaiter in awaitersToDelete)
                {
                    awaiters.Remove(awaiter);
                }
            }
        }
    }
}