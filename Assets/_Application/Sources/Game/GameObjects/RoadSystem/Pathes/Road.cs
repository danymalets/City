using System.Collections.Generic;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes
{
    public class Road : MonoBehaviour
    {
        [SerializeField]
        private SingleLaneRoad _left;

        [SerializeField]
        private SingleLaneRoad _right;

        public void GetCheckpoints(
            Vector3 crossroadsPosition,
            out IEnumerable<Checkpoint> sources,
            out IEnumerable<Checkpoint> targets)
        {
            if (DVector3.SqrDistance(crossroadsPosition, _left.transform.position) <
                DVector3.SqrDistance(crossroadsPosition, _right.transform.position))
            {
                sources = _left.Sources;
                targets = _right.Targets;
            }
            else
            {
                targets = _left.Targets;
                sources = _right.Sources;
            }
        }
    }
}