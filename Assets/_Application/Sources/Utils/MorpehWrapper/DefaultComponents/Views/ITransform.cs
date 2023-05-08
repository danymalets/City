using UnityEngine;

namespace Sources.Utils.MorpehWrapper.DefaultComponents.Views
{
    public interface ITransform 
    {
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        Vector3 LocalScale { get; set; }
        Vector3 PointLocalToWorld(Vector3 point);
        Vector3 PointWorldToLocal(Vector3 point);
    }
}