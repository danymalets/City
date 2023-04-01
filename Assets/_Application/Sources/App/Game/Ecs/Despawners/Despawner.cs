using Sources.App.DMorpeh.MorpehUtils;
using Sources.App.Infrastructure.Services;

namespace Sources.App.Game.Ecs.Despawners
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