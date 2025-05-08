using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Sources.Utils.CommonUtils.Utils
{
    public static class Vector3Utils
    {
        public static float SqrDistance(Vector3 first, Vector3 second) =>
            Vector3.SqrMagnitude(second - first);
        
        public static Vector3 Min(this IEnumerable<Vector3> en) => en.Aggregate(Vector3.Min);
        
        public static Vector3 Max(this IEnumerable<Vector3> en) => en.Aggregate(Vector3.Max);

        public static Vector3 Abs(Vector3 vector) =>
            new(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));

        public static float ManhattanDistance(Vector3 a, Vector3 b) =>
            MathUtils.Distance(a.x, b.x) +
            MathUtils.Distance(a.y, b.y) +
            MathUtils.Distance(a.z, b.z);

    }
}