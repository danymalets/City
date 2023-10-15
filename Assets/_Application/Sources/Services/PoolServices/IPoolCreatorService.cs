using Sources.Utils.Di;

namespace Sources.Services.PoolServices
{
    public interface IPoolCreatorService : IService
    {
        void CreatePool(PoolConfig poolConfig);
        void CleanupPool(RespawnableBehaviour respawnable);
    }
}