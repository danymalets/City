using UnityEngine;

namespace Sources.Data
{
    public interface ICameraPoint
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
        float FieldOfView { get; }
    }
}