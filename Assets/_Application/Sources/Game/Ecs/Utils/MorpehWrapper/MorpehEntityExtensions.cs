using System;
using System.Collections;
using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Utils.Aspects;
using Sources.Game.Ecs.Utils.MorpehWrapper.Components;
using UnityEngine;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public static class MorpehEntityExtensions
    {
        public static ref TComponent Get<TComponent>(this Entity entity) where TComponent : struct, IComponent =>
            ref entity.GetComponent<TComponent>();
        
        public static TAspect GetAspect<TAspect>(this Entity entity) where TAspect : struct, IDAspectBase =>
            new TAspect(){Entity = entity};

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
            if (entity.NotHas<AddComponentAwaiters>())
            {
                entity.Set(new AddComponentAwaiters { List = new List<AddComponentAwaiter>() });
            }
            
            entity.Get<AddComponentAwaiters>().List
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
        
        public static Entity SetEnable<TComponent>(this Entity entity, bool enable) where TComponent : struct, IComponent
        {
            entity.Remove<TComponent>();
            if (enable)
                entity.Add<TComponent>();
            return entity;
        }
        
        public static Entity RemoveIfHas<TComponent>(this Entity entity) where TComponent : struct, IComponent
        {
            if (entity.Has<TComponent>())
                entity.Remove<TComponent>();
            return entity;
        }

        public static TMono GetMono<TMono>(this Entity entity) where TMono : IMonoComponent =>
            entity.Get<Mono<TMono>>().MonoComponent;

        public static void SetMono<TMono>(this Entity entity, TMono monoComponent) where TMono : IMonoComponent => 
            entity.Set(new Mono<TMono>() {MonoComponent = monoComponent});
        
        public static Entity SetupMono<TMonoComponent>(this Entity entity, Action<TMonoComponent> setupMono) 
            where TMonoComponent : IMonoComponent
        {
            setupMono(entity.GetMono<TMonoComponent>());
            return entity;
        }
        
        public static Entity SetupMonoIf<TMonoComponent>(this Entity entity, Func<bool> should, Action<TMonoComponent> setupMono) 
            where TMonoComponent : IMonoComponent
        {
            if (should())
                entity.SetupMono(setupMono);
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