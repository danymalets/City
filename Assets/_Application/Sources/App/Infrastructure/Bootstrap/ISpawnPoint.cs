using UnityEngine;

namespace Sources.App.Infrastructure.Bootstrap
{
    public interface ISpawnPoint
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
    }
}