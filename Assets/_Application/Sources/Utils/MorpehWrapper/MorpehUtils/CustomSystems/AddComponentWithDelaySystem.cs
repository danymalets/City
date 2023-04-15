using System.Collections.Generic;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Components;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.Utils.MorpehWrapper.MorpehUtils.CustomSystems
{
    public class AddComponentWithDelaySystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
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