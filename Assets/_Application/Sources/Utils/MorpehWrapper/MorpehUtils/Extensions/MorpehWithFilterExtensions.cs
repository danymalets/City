using Scellecs.Morpeh;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class MorpehWithFilterExtensions
    {
        public static FilterBuilder With<TComponent1, TComponent2>(this FilterBuilder filter)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent =>
            filter.With<TComponent1>().With<TComponent2>();
        
        public static FilterBuilder With<TComponent1, TComponent2, TComponent3>(this FilterBuilder filter)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent
            where TComponent3 : struct, IComponent =>
            filter.With<TComponent1>().With<TComponent2>().With<TComponent3>();
        
        public static FilterBuilder With<TComponent1, TComponent2, TComponent3, TComponent4>(this FilterBuilder filter)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent
            where TComponent3 : struct, IComponent
            where TComponent4 : struct, IComponent =>
            filter.With<TComponent1>().With<TComponent2>().With<TComponent3>().With<TComponent4>();
        
        public static FilterBuilder With<TComponent1, TComponent2, TComponent3, TComponent4, TComponent5>(this FilterBuilder filter)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent
            where TComponent3 : struct, IComponent
            where TComponent4 : struct, IComponent
            where TComponent5 : struct, IComponent =>
            filter.With<TComponent1>().With<TComponent2>().With<TComponent3>().With<TComponent4>().With<TComponent5>();

    }
}