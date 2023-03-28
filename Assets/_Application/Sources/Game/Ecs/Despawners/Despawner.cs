using Scellecs.Morpeh;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Despawners
{
    public abstract class Despawner
    {
        protected readonly DWorld _world;

        protected Despawner()
        {
            _world = DiContainer.Resolve<DWorld>();
        }
    }
}