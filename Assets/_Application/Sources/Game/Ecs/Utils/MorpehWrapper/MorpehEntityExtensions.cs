using System;
using System.Collections;
using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public static class MorpehEntityExtensions
    {
        public static ref TComponent Get<TComponent>(this Entity entity) where TComponent : struct, IComponent =>
            ref entity.GetComponent<TComponent>();

        public static bool TryGet<TComponent>(this Entity entity, out TComponent component) where TComponent : struct, IComponent
        {
            if (entity.Has<TComponent>())
            {
                component = entity.Get<TComponent>();
                return true;
            }
            else
            {
                component = default;
                return true;
            }
        }

        public static Entity Add<TComponent>(this Entity entity) where TComponent : struct, IComponent
        {
            entity.AddComponent<TComponent>();
            return entity;
        }
        
        public static void Remove<TComponent>(this Entity entity) where TComponent : struct, IComponent => 
            entity.RemoveComponent<TComponent>();

        public static Entity Set<TComponent>(this Entity entity, TComponent component) where TComponent : struct, IComponent
        {
            entity.SetComponent(component);
            return entity;
        }

        public static TMono GetMono<TMono>(this Entity entity) where TMono : IMonoComponent =>
            entity.Get<Mono<TMono>>().MonoComponent;
        
        public static List<TValue> GetList<TListOf, TValue>(this Entity entity)
            where TListOf : struct, IListOf<TValue> =>
            entity.Get<TListOf>().List;

        public static Entity AddList<TListOf, TValue>(this Entity entity)
            where TListOf : struct, IListOf<TValue> =>
            entity.Set(new TListOf{List =new List<TValue>()});
        
        public static Entity SetList<TListOf, TValue>(this Entity entity, IEnumerable<TValue> enumerable)
            where TListOf : struct, IListOf<TValue> =>
            entity.Set(new TListOf{List =new List<TValue>(enumerable)});
        
        public static Queue<TValue> GetQueue<TQueueOf, TValue>(this Entity entity)
            where TQueueOf : struct, IQueueOf<TValue> =>
            entity.Get<TQueueOf>().Queue;

        public static Entity AddQueue<TQueueOf, TValue>(this Entity entity)
            where TQueueOf : struct, IQueueOf<TValue> =>
            entity.Set(new TQueueOf{Queue =new Queue<TValue>()});
        
        public static Entity SetQueue<TQueueOf, TValue>(this Entity entity, IEnumerable<TValue> enumerable)
            where TQueueOf : struct, IQueueOf<TValue> =>
            entity.Set(new TQueueOf{Queue = new Queue<TValue>(enumerable)});

        public static void SetMono<TMono>(this Entity entity, TMono monoComponent) where TMono : IMonoComponent => 
            entity.Set(new Mono<TMono>() {MonoComponent = monoComponent});
        
        public static Entity SetupMono<TMonoComponent>(this Entity entity, Action<TMonoComponent> setupMono) 
            where TMonoComponent : IMonoComponent
        {
            setupMono(entity.GetMono<TMonoComponent>());
            return entity;
        }
        
        public static void DespawnMono(this Entity entity) => 
            entity.Get<MonoEntityAccess>().MonoEntity.Despawn();
    }
}