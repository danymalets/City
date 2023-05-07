using System;
using Scellecs.Morpeh;
using Sources.Utils.MorpehWrapper.Aspects;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class EntityAspectExtensions
    {
        public static Entity SetupAspect<TAspect>(this Entity entity, Action<TAspect> accessValue) 
            where TAspect : struct, IDAspectBase
        {
            accessValue(entity.GetAspect<TAspect>());
            return entity;
        }
        
        public static Entity SetupAspectIf<TAspect>(this Entity entity, Func<bool> ifFunc, Action<TAspect> accessValue) 
            where TAspect : struct, IDAspectBase
        {
            if (ifFunc())
                accessValue(entity.GetAspect<TAspect>());
            return entity;
        }
    }
}