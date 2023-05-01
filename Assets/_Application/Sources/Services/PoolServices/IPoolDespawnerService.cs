using Sources.Utils.Di;

namespace Sources.Services.PoolServices
{
    public interface IPoolDespawnerService : IService
    {
        void Despawn<T>(T instance)
            where T : IRespawnable;
    }
}