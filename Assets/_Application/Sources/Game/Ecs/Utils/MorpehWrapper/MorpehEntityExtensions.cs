using System;
using System.Collections;
using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Utils.MorpehWrapper.Components;
using UnityEngine;

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
                return false;
            }
        }

        public static Entity Add<TComponent>(this Entity entity) where TComponent : struct, IComponent
        {
            entity.AddComponent<TComponent>();
            return entity;
        }
        
        public static ref TComponent AddAndGet<TComponent>(this Entity entity) where TComponent : struct, IComponent => 
            ref entity.AddComponent<TComponent>();

        public static ref TComponent GetOrCreate<TComponent>(this Entity entity) where TComponent : struct, IComponent
        {
            if (entity.Has<TComponent>())
            {
                return ref entity.Get<TComponent>();
            }
            else
            {
                return ref entity.AddAndGet<TComponent>();
            }
        }
        
        public static Entity AddWithDelay<TComponent>(this Entity entity, float delay)
            where TComponent : struct, IComponent =>
            entity.SetWithDelay(delay, new TComponent());
        
        public static Entity SetWithDelay<TComponent>(this  Entity entity, float delay, TComponent component)
            where TComponent : struct, IComponent
        {
            entity.GetOrCreateList<AddComponentAwaiters, AddComponentAwaiter>()
                .Add(new AddComponentAwaiter
            {
                Delay = delay,
                ComponentWrapper = new ComponentWrapper<TComponent>(component),
            });
            return entity;
        }

        public static bool NotHas<TComponent>(this Entity entity) where TComponent : struct, IComponent =>
            !entity.Has<TComponent>();
        
        public static void AddIfNotHas<TComponent>(this Entity entity) where TComponent : struct, IComponent
        {
            if (entity.NotHas<TComponent>())
                entity.Add<TComponent>();
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
        
        public static void RemoveList<TListOf, TValue>(this Entity entity)
            where TListOf : struct, IListOf<TValue> =>
            entity.Remove<TListOf>();

        public static Entity AddList<TListOf, TValue>(this Entity entity)
            where TListOf : struct, IListOf<TValue> =>
            entity.Set(new TListOf{List =new List<TValue>()});
        
        public static List<TValue> AddAndGetList<TListOf, TValue>(this Entity entity)
            where TListOf : struct, IListOf<TValue>
        {
            List<TValue> list = new ();
            entity.Set(new TListOf { List = list });
            return list;
        }

        public static List<TValue> GetOrCreateList<TListOf, TValue>(this Entity entity)
            where TListOf : struct, IListOf<TValue>
        {
            if (entity.TryGet(out TListOf listOf))
            {
                return listOf.List;
            }
            else
            {
                return entity.AddAndGetList<TListOf, TValue>();
            }
        }

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

        public static MonoEntity GetMonoEntity(this Entity entity) =>
            entity.Get<MonoEntityAccess>().MonoEntity;
        
        public static void DespawnMono(this Entity entity)
        {
            entity.GetMonoEntity().Cleanup();
            entity.GetMonoEntity().Despawn();
        }
    }
}