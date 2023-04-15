using UnityEngine;
using UnityEngine.Assertions;

namespace _Application.Sources.Utils.CommonUtils.Libs
{
    public class DBox
    {
        public Vector3 Center { get; }
        public Quaternion Rotation { get; }
        public Vector3 Size { get; }

        public DBox(Vector3 center, Quaternion rotation, Vector3 size)
        {
            Center = center;
            Rotation = rotation;
            Size = size;
        }

        private float GetMaxDistanceFromCenterInBox(Vector3 worldDirection)
        {
            Vector3 localDirection = Quaternion.Inverse(Rotation) * worldDirection;
            Vector3 absVector = DVector3.Abs(localDirection);
            
            Assert.IsTrue(DMath.Equals(localDirection.magnitude, 1f));

            Debug.Log($"vect {localDirection} {absVector}");

            Debug.Log($"max dist {DMath.Min(Size.x / absVector.x, Size.y / absVector.y, Size.z / absVector.z)}");
            
            return DMath.Min(
                Size.x / absVector.x,
                Size.y / absVector.y, 
                Size.z / absVector.z) / 2;
        }

        public static bool IsIntersect(DBox a, DBox b)
        {
            float distance = Vector3.Distance(a.Center, b.Center);

            if (DMath.Equals(distance, 0))
                return true;

            Vector3 normal = (b.Center - a.Center).normalized;

            return DMath.GreaterOrEquals(a.GetMaxDistanceFromCenterInBox(normal) +
                                         b.GetMaxDistanceFromCenterInBox(-normal), distance);
        }
    }
}