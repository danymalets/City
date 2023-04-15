using Scellecs.Morpeh;

namespace _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class MorpehWorldExtensions
    {
       
        public static Entity CreateFromMono(this DWorld world, IMonoEntity monoEntity)
        {
            Entity entity = world.CreateEntity();
            monoEntity.Setup(entity);
            entity.Set(new MonoEntityAccess{MonoEntity = monoEntity});
            return entity;
        }
        
        public static Entity CreateWithSingleMono<TMonoComponent>(this DWorld world, TMonoComponent monoComponent)
        {
            Entity entity = world.CreateEntity();
            entity.SetAccess<TMonoComponent>(monoComponent);
            return entity;
        }

        public static ref TComponent GetSingleton<TComponent>(this DWorld world) where TComponent : struct, IComponent =>
            ref world.GetSingletonEntity<TComponent>().Get<TComponent>();


        public static Entity GetSingletonEntity<TComponent>(this DWorld world) where TComponent : struct, IComponent =>
            world.Filter<TComponent>().GetSingleton();

        public static TComponent GetAccessSingleton<TComponent>(this DWorld world) =>
            world.GetSingleton<AccessTo<TComponent>>().AccessValue;
    }
}