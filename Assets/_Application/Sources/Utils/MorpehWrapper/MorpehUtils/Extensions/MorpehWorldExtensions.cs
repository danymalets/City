using System;
using Scellecs.Morpeh;
using Sources.Services.PoolServices;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
{
    public static class MorpehWorldExtensions
    {
        public static Entity CreateFromMono(this DWorld world, MonoEntity monoEntity)
        {
            Entity entity = world.CreateEntity();
            monoEntity.Setup(entity);
            entity.SetRef<MonoEntity>(monoEntity);
            entity.SetRef<RespawnableBehaviour>(monoEntity);
            return entity;
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