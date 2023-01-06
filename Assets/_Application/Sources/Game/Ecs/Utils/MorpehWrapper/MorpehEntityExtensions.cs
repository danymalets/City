using System;
using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public static class MorpehEntityExtensions
    {
        public static ref TComponent Get<TComponent>(this Entity entity) where TComponent : struct, IComponent =>
            ref entity.GetComponent<TComponent>();

        public static Entity Add<TComponent>(this Entity entity) where TComponent : struct, IComponent
        {
            entity.AddComponent<TComponent>();
            return entity;
        }
        
        public static void Remove<TComponent>(this Entity entity) where TComponent : struct, IComponent => 
            entity.RemoveComponent<TComponent>();

        public static Entity Set<TComponent>(this Entity entity, TComponent component) where TComponent : struct, IComponent
        {
            entity.SetComponent(component);
            return entity;
        }

        public static TMono GetMono<TMono>(this Entity entity) where TMono : IMonoComponent =>
            entity.Get<Mono<TMono>>().MonoComponent;

        public static void SetMono<TMono>(this Entity entity, TMono monoComponent) where TMono : IMonoComponent => 
            entity.Set(new Mono<TMono>() {MonoComponent = monoComponent});
        
        public static Entity SetupMono<TMonoComponent>(this Entity entity, Action<TMonoComponent> setupMono) 
            where TMonoComponent : IMonoComponent
        {
            setupMono(entity.GetMono<TMonoComponent>());
            return entity;
        }

    }
}