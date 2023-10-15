using System;
using Scellecs.Morpeh;
using Sources.Services.PoolServices;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class MorpehWorldExtensions
    {
        public static Entity CreateFromMono(this DWorld world, IMonoEntity monoEntity)
        {
            Entity entity = world.CreateEntity();
            monoEntity.Setup(entity);
            entity.SetRef<IMonoEntity>(monoEntity);
            return entity;
        }
        
        public static Entity CreateFromRespawnableMono(this DWorld world, MonoEntity monoEntity)
        {
            return world.CreateFromMono(monoEntity)
                .SetRef<RespawnableBehaviour>(monoEntity);
        }

        public static Entity GetSingleton<TComponent>(this DWorld world) where TComponent : struct, IComponent
        {
            if (world.Filter<TComponent>().Build().TryGetSingle(out Entity entity))
            {
                return entity;
            }
            else
            {
                throw new InvalidOperationException($"Not single: length:{world.Filter<TComponent>().Build()}");
            }
        }
    }
}