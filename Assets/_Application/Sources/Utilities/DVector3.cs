using UnityEngine;

namespace Sources.Utilities
{
    public static class DVector3
    {
        public static float SqrDistance(Vector3 first, Vector3 second) =>
            Vector3.SqrMagnitude(second - first);
    }
}