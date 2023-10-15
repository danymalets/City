using System;
using System.Collections.Generic;
using UnityEngine;

namespace Sources.Services.PoolServices
{
    public partial class PoolService
    {
        public T Spawn<T>(T prefab, Transform parent, Vector3 position, Quaternion rotation)
            where T : RespawnableBehaviour
        {
            T respawnable = Spawn(prefab);
            respawnable.transform.SetParent(parent);
            respawnable.transform.localPosition = position;
            respawnable.transform.localRotation = rotation;
            return respawnable;
        }

        public T Spawn<T>(T prefab, Vector3 position)
            where T : RespawnableBehaviour
        {
            T respawnable = Spawn(prefab);
            respawnable.transform.localPosition = position;
            return respawnable;
        }

        public T Spawn<T>(T prefab, Vector3 position, Quaternion rotation)
            where T : RespawnableBehaviour
        {
            T respawnable = Spawn(prefab);
            respawnable.transform.localPosition = position;
            respawnable.transform.localRotation = rotation;
            return respawnable;
        }

        public T Spawn<T>(T prefab, Transform parent)
            where T : RespawnableBehaviour
        {
            T respawnable = Spawn(prefab);
            respawnable.transform.SetParent(parent);
            respawnable.transform.localPosition = Vector3.zero;
            respawnable.transform.localRotation = Quaternion.identity;
            return respawnable;
        }
    }
}