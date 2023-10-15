using System;
using Scellecs.Morpeh;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.MorpehWrapper.Aspects;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class EntityDefaultExtensions
    {
        public static ref TComponent Get<TComponent>(this Entity entity) where TComponent : struct, IComponent
        {
#if FORCE_DEBUG
            DAssert.IsTrue(entity.Has<TComponent>());
#endif
            return ref entity.GetComponent<TComponent>();
        }

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
        
        public static bool TryGetRef<TRef>(this Entity entity, out TRef reference) where TRef : class
        {
            if (entity.HasRef<TRef>())
            {
                reference = entity.GetRef<TRef>();
                return true;
            }
            else
            {
                reference = default;
                return false;
            }
        }

        public static Entity Add<TComponent>(this Entity entity) where TComponent : struct, IComponent
        {
#if FORCE_DEBUG
            DAssert.IsTrue(entity.NotHas<TComponent>(), "Cannot add, entity also has this component");
#endif
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
        

        public static bool NotHas<TComponent>(this Entity entity) where TComponent : struct, IComponent =>
            !entity.Has<TComponent>();
        
        public static void AddIfNotHas<TComponent>(this Entity entity) where TComponent : struct, IComponent
        {
            if (entity.NotHas<TComponent>())
                entity.Add<TComponent>();
        }
        
        public static void Remove<TComponent>(this Entity entity) 
            where TComponent : struct, IComponent
        {
#if FORCE_DEBUG
            DAssert.IsTrue(entity.Has<TComponent>());
#endif
            entity.RemoveComponent<TComponent>();
        }

        public static Entity Set<TComponent>(this Entity entity, TComponent component) where TComponent : struct, IComponent
        {
            entity.SetComponent(component);
            return entity;
        }
        
        public static Entity SetEnable<TComponent>(this Entity entity, bool enable) where TComponent : struct, IComponent
        {
            entity.RemoveIfHas<TComponent>();
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
        
        public static Entity AddIf<TComponent>(this Entity entity, Func<bool> ifFunc) 
            where TComponent : struct, IComponent
        {
            if (ifFunc())
                entity.Add<TComponent>();
            return entity;
        }
        
        public static Entity SetIf<TComponent>(this Entity entity, Func<bool> ifFunc, TComponent component) 
            where TComponent : struct, IComponent
        {
            if (ifFunc())
                entity.Set(component);
            return entity;
        }
    }
}