
using UnityEngine;

namespace Sources.Utilities.Extensions
{
    public static class QuaternionExtensions
    {
        public static Quaternion WithEulerX(this Quaternion rotation, float x) => 
            Quaternion.Euler(x, rotation.eulerAngles.y, rotation.eulerAngles.z);
        
        public static Quaternion WithEulerY(this Quaternion rotation, float y) => 
            Quaternion.Euler(rotation.eulerAngles.x, y, rotation.eulerAngles.z);
        
        public static Quaternion WithEulerZ(this Quaternion rotation, float z) => 
            Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, z);
    }
}