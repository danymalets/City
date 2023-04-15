using Sources.Utils.Di;

namespace Sources.CommonServices.PoolServices
{
    public interface IPoolDespawnerService : IService
    {
        void Despawn<T>(T instance)
            where T : IRespawnable;
    }
}