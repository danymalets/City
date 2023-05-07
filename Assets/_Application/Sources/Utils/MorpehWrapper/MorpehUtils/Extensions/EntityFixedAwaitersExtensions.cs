using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.MorpehWrapper.MorpehUtils.Components;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class EntityFixedAwaitersExtensions
    {
        public static Entity AddWithFixedDelay<TComponent>(this Entity entity, float delay)
            where TComponent : struct, IComponent =>
            entity.SetWithFixedDelay(delay, new TComponent());

        public static Entity AddForFixedSeconds<TComponent>(this Entity entity, float duration)
            where TComponent : struct, IComponent
        {
            entity.Add<TComponent>();
            entity.RemoveWithFixedDelay<TComponent>(duration);
            return entity;
        }

        public static Entity RemoveWithFixedDelay<TComponent>(this Entity entity, float delay)
            where TComponent : struct, IComponent
        {
            entity.Get<FixedAwaiters>().List
                .Add(new ComponentAwaiter
                {
                    Delay = delay,
                    ComponentWrapper = new RemoveComponentWrapper<TComponent>(),
                });
            return entity;
        }

        public static Entity SetWithFixedDelay<TComponent>(this Entity entity, float delay, TComponent component)
            where TComponent : struct, IComponent
        {
            entity.Get<FixedAwaiters>().List
                .Add(new ComponentAwaiter
                {
                    Delay = delay,
                    ComponentWrapper = new SetComponentWrapper<TComponent>(component),
                });
            return entity;
        }

        public static Entity AllowFixedAwaiters(this Entity entity) =>
            entity.Set(new FixedAwaiters { List = new List<ComponentAwaiter>() });
    }
}