using Sources.Utils.CommonUtils.Libs;
using UnityEngine;

namespace Sources.App.Data.Simulations
{
    public readonly struct SimulationShapeData
    {
        public Vector2 Center { get; }
        public Vector2 NormalDirection { get; }
        public float SqrRadius { get; }
        public float BackDistance { get; }

        public SimulationShapeData(Vector2 center, Vector2 normalDirection,
            float radius, float backDistance)
        {
            Center = center;
            NormalDirection = normalDirection;
            SqrRadius = DMath.Sqr(radius);
            BackDistance = backDistance;
        }

        public bool IsInside(Vector2 point)
        {
            Vector2 directionToPoint = point - Center;
            float forwardDistance = Vector2.Dot(NormalDirection, directionToPoint);
            return forwardDistance > 0 ? directionToPoint.sqrMagnitude < SqrRadius : 
                directionToPoint.sqrMagnitude < SqrRadius && -forwardDistance < BackDistance;
        }
    }
}