using Sources.Services.Di;
using UnityEngine;

namespace Sources.Services.Pool
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