using Sources.Data.MonoViews;
using UnityEngine;

namespace Sources.Monos.Bootstrap
{
    public class SpawnPoint : MonoBehaviour, ISpawnPoint
    {
        public Vector3 Position => transform.position;
        public Quaternion Rotation => transform.rotation;
    }
}