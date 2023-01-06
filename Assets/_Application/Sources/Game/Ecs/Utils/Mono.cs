using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Utils
{
    public struct Mono<TView> : IComponent where TView : IMonoComponent
    {
        public TView MonoComponent;
    }
}