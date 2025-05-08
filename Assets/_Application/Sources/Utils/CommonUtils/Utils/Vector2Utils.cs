using UnityEngine;

namespace Sources.Utils.CommonUtils.Utils
{
    public static class Vector2Utils
    {
        public static float SqrDistance(Vector2 first, Vector2 second) =>
            Vector2.SqrMagnitude(second - first);
        
        public static float Dot(Vector2 first, Vector2 second) =>
            Vector2.SqrMagnitude(second - first);
    }
}