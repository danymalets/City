using UnityEngine;

namespace Sources.Utilities
{
    public static class Vector3Utility
    {
        public static float SqrDistance(Vector3 first, Vector3 second) =>
            Vector3.SqrMagnitude(second - first);
    }
}