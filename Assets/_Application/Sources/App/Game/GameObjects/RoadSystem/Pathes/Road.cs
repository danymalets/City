using System.Collections.Generic;
using System.Linq;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.App.Game.GameObjects.RoadSystem.Pathes
{
    public class Road : MonoBehaviour
    {
        [SerializeField]
        private OneWayRoad _left;

        [SerializeField]
        private OneWayRoad _right;

        [SerializeField]
        private bool _isSpawnPoint = true;


        public bool IsSpawnPoint => _isSpawnPoint;

        public IEnumerable<RoadLane> RoadLanes => 
            _left.RoadLanes.Concat(_right.RoadLanes);
        
        // sources and targets related road
        public CrossroadsSideData GetSideData(
            Vector3 crossroadsPosition)
        {
            if (DVector3.SqrDistance(crossroadsPosition, _left.Sources.First().Position) <
                DVector3.SqrDistance(crossroadsPosition, _right.Sources.First().Position))
            {
                return new CrossroadsSideData(_left.Sources, _right.Targets);
            }
            else
            {
                return new CrossroadsSideData(_right.Sources, _left.Targets);
            }
        }

        public RoadLane[] GetLanesByDistanceTo(Vector3 position) =>
            RoadLanes.OrderBy(r => DVector3.SqrDistance(r.Source.Position, position)).ToArray();
    }
}