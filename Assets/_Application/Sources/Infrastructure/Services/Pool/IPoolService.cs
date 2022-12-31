namespace Sources.Infrastructure.Services.Pool
{
    public interface IPoolService : IService
    {
        T Get<T>(T prefab) where T : RespawnableBehaviour;
        
        Pool CreatePool(PoolConfig poolConfig);
        void DestroyPool(RespawnableBehaviour respawnable);
    }
}