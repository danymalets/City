using UnityEngine;

namespace _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views
{
    public interface ITransform 
    {
        Vector3 Position { get; set; }
        Quaternion Rotation { get; set; }
        Vector3 TransformPoint(Vector3 point);
        Vector3 InverseTransformPoint(Vector3 point);
    }
}