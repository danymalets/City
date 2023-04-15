using Sources.Utils.Di;

namespace Sources.CommonServices.PoolServices
{
    public interface IPoolCreatorService : IService
    {
        Pool CreatePool(PoolConfig poolConfig);
        void DestroyPool(IRespawnable respawnable);
    }
}