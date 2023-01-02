using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes
{
    public class Path
    {
        private const float AvailableError = 1f;

        private readonly float _finalProgress;
        public IConnectingPoint Source { get; }
        public IConnectingPoint Target { get; }
        public float Distance { get; }

        public Vector3 Direction { get; }
        public Vector3 NormalizedDirection { get; set; }
        
        public Path(IConnectingPoint source, IConnectingPoint target)
        {
            Source = source;
            Target = target;

            Source.Targets.Add(this);
            Target.Sources.Add(this);

            Direction = Target.Position - Source.Position;
            Distance = Direction.magnitude;
            NormalizedDirection = Direction.normalized;
        }

        public bool IsEnded(Vector3 point) =>
            GetProgress(point) >= 1f;

        public bool IsOnPath(Vector3 point) =>
            SqrDistanceTo(point) <= AvailableError * AvailableError &&
            GetElapsedDistance(point).InRange(-AvailableError, Distance + AvailableError);

        public float GetElapsedDistance(Vector3 point) =>
            Vector3.Dot(point - Source.Position, Direction) /
            Direction.magnitude;
        
        public float GetProgress(Vector3 point) =>
            Vector3.Dot(point - Source.Position, Direction) /
            Direction.sqrMagnitude;

        public float SqrDistanceTo(Vector3 point) =>
            DVector3.SqrDistance(
                Vector3.Lerp(Source.Position, Target.Position, GetProgress(point)),
                point);
    }
}