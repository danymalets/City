using System;
using Scellecs.Morpeh;

namespace Sources.Utils.MorpehWrapper.MorpehUtils.Extensions
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