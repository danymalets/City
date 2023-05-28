using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Views
{
    public interface IReadonlyTransform 
    {
        Vector3 Position { get; }
        Quaternion Rotation { get; }
        Vector3 LocalScale { get; }
        Vector3 PointLocalToWorld(Vector3 point);
        Vector3 PointWorldToLocal(Vector3 point);
    }
}