using UnityEngine;

namespace Sources.Infrastructure.Bootstrap
{
    public interface ISpawnPoint
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
    }
}