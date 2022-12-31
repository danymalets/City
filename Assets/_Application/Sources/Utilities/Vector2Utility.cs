using UnityEngine;

namespace Sources.Utilities
{
    public static class Vector2Utility
    {
        public static float SqrDistance(Vector2 first, Vector2 second) =>
            Vector2.SqrMagnitude(second - first);
    }
}