using UnityEngine;

namespace _Application.Sources.Monos.Bootstrap
{
    public interface ISpawnPoint
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
    }
}