using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace _Application.Sources.Utils.CommonUtils.Libs
{
    public static class DVector3
    {
        public static float SqrDistance(Vector3 first, Vector3 second) =>
            Vector3.SqrMagnitude(second - first);
        
        public static Vector3 MinVectorValues(this IEnumerable<Vector3> en) => 
            new(
                en.Select(v => v.x).Min(),
                en.Select(v => v.y).Min(), 
                en.Select(v => v.z).Min());
        
        public static Vector3 MaxVectorValues(this IEnumerable<Vector3> en) => 
            new(
                en.Select(v => v.x).Max(),
                en.Select(v => v.y).Max(), 
                en.Select(v => v.z).Max());

        public static Vector3 Abs(Vector3 vector) =>
            new(Mathf.Abs(vector.x), Mathf.Abs(vector.y), Mathf.Abs(vector.z));

        public static float ManhattanDistance(Vector3 a, Vector3 b) =>
            DMath.Distance(a.x, b.x) +
            DMath.Distance(a.y, b.y) +
            DMath.Distance(a.z, b.z);

    }
}