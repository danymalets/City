using UnityEngine;

namespace Sources.App.Data.Points
{
    public interface ISpawnPoint
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
    }
}