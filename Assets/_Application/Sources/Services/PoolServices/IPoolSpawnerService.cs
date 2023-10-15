using Sources.Utils.Di;
using UnityEngine;

namespace Sources.Services.PoolServices
{
    public interface IPoolSpawnerService : IService
    {
        T Spawn<T>(T prefab)
            where T : RespawnableBehaviour;

        T Spawn<T>(T prefab, Vector3 at)
            where T : RespawnableBehaviour;

        T Spawn<T>(T prefab, Vector3 at, Quaternion rotation)
            where T : RespawnableBehaviour;

        T Spawn<T>(T prefab, Transform parent, Vector3 at, Quaternion rotation)
            where T : RespawnableBehaviour;

        T Spawn<T>(T prefab, Transform parent)
            where T: RespawnableBehaviour;
    }
}