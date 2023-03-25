using System;
using Scellecs.Morpeh;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Pool;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public static class MorpehWorldExtensions
    {
        public static Entity CreateFromMono(this World world, MonoEntity monoEntity)
        {
            Entity entity = world.CreateEntity();
            monoEntity.Setup(entity);
            entity.Set(new MonoEntityAccess{MonoEntity = monoEntity});
            return entity;
        }
        
        public static Entity CreateWithSingleMono<TMonoComponent>(this World world, TMonoComponent monoComponent)
        {
            Entity entity = world.CreateEntity();
            entity.SetAccess<TMonoComponent>(monoComponent);
            return entity;
        }

        public static ref TComponent GetSingleton<TComponent>(this World world) where TComponent : struct, IComponent =>
            ref world.GetSingletonEntity<TComponent>().Get<TComponent>();


        public static Entity GetSingletonEntity<TComponent>(this World world) where TComponent : struct, IComponent =>
            world.Filter<TComponent>().GetSingleton();

        public static TComponent GetAccessSingleton<TComponent>(this World world) =>
            world.GetSingleton<AccessTo<TComponent>>().AccessValue;
    }
}