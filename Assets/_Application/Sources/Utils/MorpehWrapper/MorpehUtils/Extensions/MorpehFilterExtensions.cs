using System;
using System.Linq;
using Scellecs.Morpeh;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class MorpehFilterExtensions
    {
        public static FilterBuilder Without<TComponent1, TComponent2>(this FilterBuilder filter)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent =>
            filter.Without<TComponent1>().Without<TComponent2>();
        
        public static FilterBuilder Without<TComponent1, TComponent2, TComponent3>(this FilterBuilder filter)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent
            where TComponent3 : struct, IComponent =>
            filter.Without<TComponent1>().Without<TComponent2>().Without<TComponent3>();
        
        public static FilterBuilder Without<TComponent1, TComponent2, TComponent3, TComponent4>(this FilterBuilder filter)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent
            where TComponent3 : struct, IComponent
            where TComponent4 : struct, IComponent =>
            filter.Without<TComponent1>().Without<TComponent2>().Without<TComponent3>().Without<TComponent4>();
        
        public static FilterBuilder Without<TComponent1, TComponent2, TComponent3, TComponent4, TComponent5>(this FilterBuilder filter)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent
            where TComponent3 : struct, IComponent
            where TComponent4 : struct, IComponent
            where TComponent5 : struct, IComponent =>
            filter.Without<TComponent1>().Without<TComponent2>().Without<TComponent3>().Without<TComponent4>().Without<TComponent5>();
        
        public static bool Any(this Filter filter)
        {
            foreach (Entity entity in filter)
            {
                return true;
            }
            return false;
        }
        
        public static bool TryGetSingleton(this Filter filter, out Entity entityAnswer)
        {
            entityAnswer = default;
            bool wasAns = false;
            foreach (var tmp in filter)
            {
                if (wasAns)
                {
                    throw new InvalidOperationException("Filter not singleton");
                }
                    
                entityAnswer = tmp;
                wasAns = true;
            }
            return wasAns;
        }

        public static Entity GetSingleton(this Filter filter)
        {
            if (filter.TryGetSingleton(out Entity entity))
            {
                return entity;
            }
            else
            {
                throw new InvalidOperationException("No entities in filter");
            }
        }
    }
}