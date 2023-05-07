using System;
using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.MorpehUtils.Components;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class EntityRefExtensions
    {
        public static TRef GetRef<TRef>(this Entity entity) where TRef : class =>
            entity.Get<Ref<TRef>>().Reference;
        
        public static void RemoveRef<TRef>(this Entity entity) where TRef : class =>
            entity.Remove<Ref<TRef>>();
        
        public static bool HasRef<TRef>(this Entity entity) where TRef : class =>
            entity.Has<Ref<TRef>>();

        public static Entity SetRef<TRef>(this Entity entity, TRef accessValue) where TRef : class => 
            entity.Set(new Ref<TRef> {Reference = accessValue});
        
        public static Entity SetupRef<TRef>(this Entity entity, Action<TRef> accessValue) 
            where TRef : class
        {
            accessValue(entity.GetRef<TRef>());
            return entity;
        }

        public static Entity SetupRefIf<TRef>(this Entity entity,
            Func<bool> ifFunc, Action<TRef> accessValue) where TRef : class
        {
            if (ifFunc())
                entity.SetupRef(accessValue);
            return entity;
        }
    }
}