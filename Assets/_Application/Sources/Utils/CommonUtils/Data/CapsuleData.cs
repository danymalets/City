using UnityEngine;

namespace _Application.Sources.Utils.CommonUtils.Data
{
    public struct CapsuleData
    {
        public Vector3 Start { get; }
        public Vector3 End { get; }

        public float Radius { get; }

        public float Height => Vector3.Distance(Start, End) + Radius * 2;
        
        public CapsuleData(Vector3 start, Vector3 end, float radius)
        {
            Start = start;
            End = end;
            Radius = radius;
        }
    }
}