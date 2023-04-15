using UnityEngine;

namespace Sources.App.Data.Points
{
    public interface ICameraPoint
    {
        public Vector3 Position { get; }
        public Quaternion Rotation { get; }
        float FieldOfView { get; }
    }
}