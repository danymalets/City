using UnityEngine;

namespace Sources.Utilities.Extensions
{
    public static class TransformExtensions
    {
        public static void SetRotationX(this Transform transform, float x) => 
            transform.eulerAngles = new Vector3(x, transform.eulerAngles.y, transform.eulerAngles.z);
    }
}