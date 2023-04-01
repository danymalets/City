using Sources.Di;

namespace Sources.Services.Pool
{
    public interface IPoolCreatorService : IService
    {
        Pool CreatePool(PoolConfig poolConfig);
        void DestroyPool(RespawnableBehaviour respawnable);
    }
}