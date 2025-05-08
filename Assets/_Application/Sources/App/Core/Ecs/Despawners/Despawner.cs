using Sources.Services.PoolServices;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils;

namespace Sources.App.Core.Ecs.Despawners
{
    public abstract class Despawner
    {
        protected readonly CustomWorld _world;
        protected readonly IPoolDespawnerService _poolDespawner;
        
        protected Despawner()
        {
            _world = DiContainer.Resolve<CustomWorld>();
            _poolDespawner = DiContainer.Resolve<IPoolDespawnerService>();
        }
    }
}