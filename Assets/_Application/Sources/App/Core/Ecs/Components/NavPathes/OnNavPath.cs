using Scellecs.Morpeh;
using UnityEngine;

namespace Sources.App.Core.Ecs.Components.NavPathes
{
    public struct OnNavPath : IComponent
    {
        public Vector3[] Path;
        public int LastCompetedPoint;
        public float DistanceToTargetToComplete;
    }
}