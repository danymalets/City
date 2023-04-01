using Sources.Di;
using Sources.DMorpeh.MorpehUtils;

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