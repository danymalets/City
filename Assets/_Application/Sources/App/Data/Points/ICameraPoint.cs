using UnityEngine;

namespace Sources.Data.Points
{
    public interface ICameraPoint
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
        float FieldOfView { get; }
    }
}