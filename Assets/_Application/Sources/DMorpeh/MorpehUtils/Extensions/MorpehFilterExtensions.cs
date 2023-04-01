using System;
using System.Linq;
using Scellecs.Morpeh;

namespace Sources.DMorpeh.MorpehUtils.Extensions
{
    public static class MorpehFilterExtensions
    {
        public static Filter Without<TComponent1, TComponent2>(this Filter filter)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent =>
            filter.Without<TComponent1>().Without<TComponent2>();
        
        public static Filter Without<TComponent1, TComponent2, TComponent3>(this Filter filter)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent
            where TComponent3 : struct, IComponent =>
            filter.Without<TComponent1>().Without<TComponent2>().Without<TComponent3>();
        
        public static Filter Without<TComponent1, TComponent2, TComponent3, TComponent4>(this Filter filter)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent
            where TComponent3 : struct, IComponent
            where TComponent4 : struct, IComponent =>
            filter.Without<TComponent1>().Without<TComponent2>().Without<TComponent3>().Without<TComponent4>();
        
        public static Filter Without<TComponent1, TComponent2, TComponent3, TComponent4, TComponent5>(this Filter filter)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent
            where TComponent3 : struct, IComponent
            where TComponent4 : struct, IComponent
            where TComponent5 : struct, IComponent =>
            filter.Without<TComponent1>().Without<TComponent2>().Without<TComponent3>().Without<TComponent4>().Without<TComponent5>();

        public static void ShouldBeAtLeast(this Filter filter, int minCount)
        {
            if (filter.Count() < minCount)
                throw new InvalidOperationException();
        }
        
        public static void ShouldBe(this Filter filter, int count)
        {
            if (filter.Count() != count)
                throw new InvalidOperationException();
        }

        public static Entity GetSingleton(this Filter filter)
        {
            filter.ShouldBe(1);
            return filter.First();
        }
    }
}