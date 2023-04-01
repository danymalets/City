using Scellecs.Morpeh;

namespace Sources.App.DMorpeh.MorpehUtils.Extensions
{
    public static class MorpehWorldFilterExtensions
    {
        public static Filter Filter<TComponent>(this DWorld world) where TComponent : struct, IComponent =>
            world.Filter.With<TComponent>();
        
        public static Filter Filter<TComponent1, TComponent2>(this DWorld world)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent =>
            world.Filter.With<TComponent1>().With<TComponent2>();
        
        public static Filter Filter<TComponent1, TComponent2, TComponent3>(this DWorld world)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent
            where TComponent3 : struct, IComponent =>
            world.Filter.With<TComponent1>().With<TComponent2>().With<TComponent3>();
        
        public static Filter Filter<TComponent1, TComponent2, TComponent3, TComponent4>(this DWorld world)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent
            where TComponent3 : struct, IComponent
            where TComponent4 : struct, IComponent =>
            world.Filter.With<TComponent1>().With<TComponent2>().With<TComponent3>().With<TComponent4>();
        
        public static Filter Filter<TComponent1, TComponent2, TComponent3, TComponent4, TComponent5>(this DWorld world)
            where TComponent1 : struct, IComponent 
            where TComponent2 : struct, IComponent
            where TComponent3 : struct, IComponent
            where TComponent4 : struct, IComponent
            where TComponent5 : struct, IComponent =>
            world.Filter.With<TComponent1>().With<TComponent2>().With<TComponent3>().With<TComponent4>().With<TComponent5>();
    }
}