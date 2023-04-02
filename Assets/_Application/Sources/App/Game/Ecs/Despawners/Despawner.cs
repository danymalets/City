using Sources.Services.Di;
using Sources.Services.Pool;
using Sources.Utils.DMorpeh.MorpehUtils;

namespace Sources.App.Game.Ecs.Despawners
{
    public abstract class Despawner
    {
        protected readonly DWorld _world;
        protected readonly IPoolDespawnerService _poolDespawner;
        
        protected Despawner()
        {
            _world = DiContainer.Resolve<DWorld>();
            _poolDespawner = DiContainer.Resolve<IPoolDespawnerService>();
        }
    }
}