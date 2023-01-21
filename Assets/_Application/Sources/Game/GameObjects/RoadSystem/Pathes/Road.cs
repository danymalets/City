using System.Collections.Generic;
using System.Linq;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes
{
    public class Road : MonoBehaviour
    {
        [SerializeField]
        private OneWayRoad _left;

        [SerializeField]
        private OneWayRoad _right;

        public IEnumerable<RoadLane> RoadLanes => 
            _left.RoadLanes.Concat(_right.RoadLanes);
        
        // sources and targets related road
        public CrossroadsSideData GetSideData(
            Vector3 crossroadsPosition)
        {
            if (DVector3.SqrDistance(crossroadsPosition, _left.transform.position) <
                DVector3.SqrDistance(crossroadsPosition, _right.transform.position))
            {
                return new CrossroadsSideData(_left.Sources, _right.Targets);
            }
            else
            {
                return new CrossroadsSideData(_right.Sources, _left.Targets);
            }
        }
    }
}