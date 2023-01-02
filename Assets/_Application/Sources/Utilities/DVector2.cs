using UnityEngine;

namespace Sources.Utilities
{
    public static class DVector2
    {
        public static float SqrDistance(Vector2 first, Vector2 second) =>
            Vector2.SqrMagnitude(second - first);
    }
}