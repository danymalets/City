using Sources.Utils.Di;
using UnityEngine;

namespace Sources.CommonServices.PoolServices
{
    public interface IPoolSpawnerService : IService
    {
        T Spawn<T>(T prefab)
            where T : IRespawnable;

        T Spawn<T>(T prefab, Vector3 at)
            where T : IRespawnable;

        T Spawn<T>(T prefab, Vector3 at, Quaternion rotation)
            where T : IRespawnable;

        T Spawn<T>(T prefab, Transform parent, Vector3 at, Quaternion rotation)
            where T : IRespawnable;

        T Spawn<T>(T prefab, Transform parent)
            where T: IRespawnable;
    }
}