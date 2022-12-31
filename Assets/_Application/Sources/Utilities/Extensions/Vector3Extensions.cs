using UnityEngine;

namespace Sources.Utilities.Extensions
{
    public static class Vector3Extensions
    {
        public static Vector3 WithY(this Vector3 vector, float y) =>
            new Vector3(vector.x, y, vector.z);

    }
}