using System.Collections.Generic;
using UnityEngine;

namespace Sources.Utils.CommonUtils.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 WithX(this Vector3 vector, float x) => new(x, vector.y, vector.z);
        public static Vector3 WithY(this Vector3 vector, float y) => new(vector.x, y, vector.z);
        public static Vector3 WithZ(this Vector3 vector, float z) => new(vector.x, vector.y, z);
        public static Vector3 WithDeltaZ(this Vector3 vector, float z) => new(vector.x, vector.y, vector.z + z);
        public static Vector2 GetXZ(this Vector3 vector) => new(vector.x, vector.z);
        public static Vector3 GetX0Z(this Vector3 vector) => new(vector.x, 0, vector.z);

        public static Vector3 Average(this IEnumerable<Vector3> en)
        {
            Vector3 result = Vector3.zero;
            int count = 0;
            foreach (Vector3 vector in en)
            {
                result += vector;
                count++;
            }

            return result / count;
        }
    }
}