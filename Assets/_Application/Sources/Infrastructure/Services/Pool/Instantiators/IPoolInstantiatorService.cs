using UnityEngine;

namespace Sources.Infrastructure.Services.Pool.Instantiators
{
    public interface IPoolInstantiatorService : IService
    {
        T Instantiate<T>(T prefab)
            where T : RespawnableBehaviour;

        T Instantiate<T>(T prefab, Vector3 at)
            where T : RespawnableBehaviour;

        T Instantiate<T>(T prefab, Vector3 at, Quaternion rotation)
            where T : RespawnableBehaviour;

        T Instantiate<T>(T prefab, Transform parent, Vector3 at, Quaternion rotation)
            where T : RespawnableBehaviour;

        T Instantiate<T>(T prefab, Transform parent)
            where T: RespawnableBehaviour;
    }
}