using System;
using Scellecs.Morpeh;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Pool.Instantiators;

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
        
        

        public static Entity CreateWithEmptyMono(this World world)
        {
            return world.CreateEntity();;
        }

        public static Entity CreateFromMonoPrefab(this World world, MonoEntity prefab)
        {
            IPoolSpawnerService poolSpawner = DiContainer.Resolve<IPoolSpawnerService>();
            MonoEntity monoEntity = poolSpawner.Spawn(prefab);
            return world.CreateFromMono(monoEntity);
        }

        
    }
}