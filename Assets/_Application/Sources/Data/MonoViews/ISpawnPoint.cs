using UnityEngine;

namespace Sources.Data.MonoViews
{
    public interface ISpawnPoint
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
    }
}