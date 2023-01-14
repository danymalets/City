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
            return entity;
        }
        
        public static Entity CreateWithSingleMono<TMonoComponent>(this World world, TMonoComponent monoComponent)
            where TMonoComponent : IMonoComponent
        {
            Entity entity = world.CreateEntity();
            entity.SetMono<TMonoComponent>(monoComponent);
            return entity;
        }
        

        public static Entity CreateFromMonoPrefab(this World world, MonoEntity prefab)
        {
            IPoolSpawnerService poolSpawner = DiContainer.Resolve<IPoolSpawnerService>();
            MonoEntity monoEntity = poolSpawner.Spawn(prefab);
            return world.CreateFromMono(monoEntity);
        }

        public static ref TComponent GetSingleton<TComponent>(this World world) where TComponent : struct, IComponent =>
            ref world.GetSingletonEntity<TComponent>().Get<TComponent>();


        public static Entity GetSingletonEntity<TComponent>(this World world) where TComponent : struct, IComponent =>
            world.Filter<TComponent>().GetSingleton();

        public static TComponent GetMonoSingleton<TComponent>(this World world) where TComponent : IMonoComponent =>
            world.GetSingleton<Mono<TComponent>>().MonoComponent;
    }
}