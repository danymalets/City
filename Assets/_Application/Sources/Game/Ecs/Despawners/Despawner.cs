using Scellecs.Morpeh;

namespace Sources.Game.Ecs.Despawners
{
    public abstract class Despawner
    {
        protected readonly World _world;

        protected Despawner(World world)
        {
            _world = world;
        }
    }
}