using _Application.Sources.Utils.Di;

namespace _Application.Sources.CommonServices.PoolServices
{
    public interface IPoolDespawnerService : IService
    {
        void Despawn<T>(T instance)
            where T : IRespawnable;
    }
}