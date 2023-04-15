using Sources.Services.Di;

namespace Sources.Services.Pool
{
    public interface IPoolDespawnerService : IService
    {
        void Despawn<T>(T instance)
            where T : IRespawnable;
    }
}