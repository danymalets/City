using UnityEngine;

namespace Sources.Data.Points
{
    public interface ISpawnPoint
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
    }
}