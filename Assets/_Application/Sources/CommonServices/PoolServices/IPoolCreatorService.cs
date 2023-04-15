using _Application.Sources.Utils.Di;

namespace _Application.Sources.CommonServices.PoolServices
{
    public interface IPoolCreatorService : IService
    {
        Pool CreatePool(PoolConfig poolConfig);
        void DestroyPool(IRespawnable respawnable);
    }
}