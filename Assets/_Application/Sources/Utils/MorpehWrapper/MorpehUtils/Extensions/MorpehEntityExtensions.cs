using System;
using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.MorpehUtils.Components;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
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
        
        public static bool TryGetAccess<TAccess>(this Entity entity, out TAccess access)
        {
            if (entity.Has<AccessTo<TAccess>>())
            {
                access = entity.GetAccess<TAccess>();
                return true;
            }
            else
            {
                access = default;
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
        
        public static ref TComponent SetAndGet<TComponent>(this Entity entity, TComponent component)
            where TComponent : struct, IComponent
        {
            entity.SetComponent<TComponent>(component);
            return ref entity.Get<TComponent>();
        }

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
            AddProcessAwaitersIfNotHas(entity);

            entity.Get<ComponentProcessAwaiters>().List
                .Add(new ComponentProcessAwaiter
                {
                    Delay = delay,
                    ComponentWrapper = new RemoveComponentWrapper<TComponent>(),
                });
            return entity;
        }

        public static Entity SetWithDelay<TComponent>(this  Entity entity, float delay, TComponent component)
            where TComponent : struct, IComponent
        {
            AddProcessAwaitersIfNotHas(entity);
            
            entity.Get<ComponentProcessAwaiters>().List
                .Add(new ComponentProcessAwaiter
            {
                Delay = delay,
                ComponentWrapper = new SetComponentWrapper<TComponent>(component),
            });
            return entity;
        }

        private static void AddProcessAwaitersIfNotHas(Entity entity)
        {
            if (entity.NotHas<ComponentProcessAwaiters>())
            {
                entity.Set(new ComponentProcessAwaiters { List = new List<ComponentProcessAwaiter>() });
            }
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

        public static TAccessible GetAccess<TAccessible>(this Entity entity) =>
            entity.Get<AccessTo<TAccessible>>().AccessValue;
        
        public static void RemoveAccess<TAccessible>(this Entity entity) =>
            entity.Remove<AccessTo<TAccessible>>();
        
        public static bool HasAccess<TAccessible>(this Entity entity) =>
            entity.Has<AccessTo<TAccessible>>();

        public static Entity SetAccess<TAccessible>(this Entity entity, TAccessible accessValue) => 
            entity.Set(new AccessTo<TAccessible> {AccessValue = accessValue});
        
        public static Entity SetupAccessible<TAccessible>(this Entity entity, Action<TAccessible> accessValue) 
        {
            accessValue(entity.GetAccess<TAccessible>());
            return entity;
        }
        
        public static Entity SetupAspect<TAspect>(this Entity entity, Action<TAspect> accessValue) 
            where TAspect : struct, IDAspectBase
        {
            accessValue(entity.GetAspect<TAspect>());
            return entity;
        }
        
        public static Entity AddIf<TComponent>(this Entity entity, Func<bool> ifFunc) 
            where TComponent : struct, IComponent
        {
            if (ifFunc())
                entity.Add<TComponent>();
            return entity;
        }
        
        public static Entity SetupAspectIf<TAspect>(this Entity entity, Func<bool> ifFunc, Action<TAspect> accessValue) 
            where TAspect : struct, IDAspectBase
        {
            if (ifFunc())
                accessValue(entity.GetAspect<TAspect>());
            return entity;
        }
        
        public static Entity SetupAccessibleIf<TAccessible>(this Entity entity, Func<bool> ifFunc, Action<TAccessible> accessValue) 
        {
            if (ifFunc())
                entity.SetupAccessible(accessValue);
            return entity;
        }

        public static IMonoEntity GetMonoEntity(this Entity entity) =>
            entity.Get<MonoEntityAccess>().MonoEntity;
        
        public static void DespawnMono(this Entity entity)
        {
            entity.GetMonoEntity().Cleanup();
        }
    }
}