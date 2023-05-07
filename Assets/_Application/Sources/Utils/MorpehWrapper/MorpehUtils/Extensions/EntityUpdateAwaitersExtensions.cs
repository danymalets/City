using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.MorpehWrapper.MorpehUtils.Components;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class EntityUpdateAwaitersExtensions
    {
        public static Entity AddWithDelay<TComponent>(this Entity entity, float delay)
            where TComponent : struct, IComponent =>
            entity.SetWithDelay(delay, new TComponent());

        public static Entity AddForSeconds<TComponent>(this Entity entity, float duration)
            where TComponent : struct, IComponent
        {
            entity.Add<TComponent>();
            entity.RemoveWithDelay<TComponent>(duration);
            return entity;
        }

        public static Entity RemoveWithDelay<TComponent>(this Entity entity, float delay)
            where TComponent : struct, IComponent
        {
            entity.Get<UpdateAwaiters>().List
                .Add(new ComponentAwaiter
                {
                    Delay = delay,
                    ComponentWrapper = new RemoveComponentWrapper<TComponent>(),
                });
            return entity;
        }

        public static Entity SetWithDelay<TComponent>(this Entity entity, float delay, TComponent component)
            where TComponent : struct, IComponent
        {
            entity.Get<UpdateAwaiters>().List
                .Add(new ComponentAwaiter
                {
                    Delay = delay,
                    ComponentWrapper = new SetComponentWrapper<TComponent>(component),
                });
            return entity;
        }

        public static Entity AllowUpdateAwaiters(this Entity entity) =>
            entity.Set(new UpdateAwaiters { List = new List<ComponentAwaiter>() });
    }
}