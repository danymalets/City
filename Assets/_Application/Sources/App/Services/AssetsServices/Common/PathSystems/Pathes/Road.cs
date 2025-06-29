using System.Collections.Generic;
using System.Linq;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;
using Sources.Utils.CommonUtils.Utils;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.PathSystems.Pathes
{
    public class Road : MonoBehaviour, IRoad
    {
        [SerializeField]
        private OneWayRoad _left;

        [SerializeField]
        private OneWayRoad _right;

        [SerializeField]
        private bool _isSpawnPoint = true;


        public bool IsSpawnPoint => _isSpawnPoint;

        public IEnumerable<IRoadLane> RoadLanes => 
            _left.RoadLanes.Concat(_right.RoadLanes);
        
        // sources and targets related road
        public CrossroadsSideData GetSideData(Vector3 crossroadsPosition)
        {
            if (Vector3Utils.SqrDistance(crossroadsPosition, _left.Sources.First().Position) <
                Vector3Utils.SqrDistance(crossroadsPosition, _right.Sources.First().Position))
            {
                return new CrossroadsSideData(_left.Sources, _right.Targets);
            }
            else
            {
                return new CrossroadsSideData(_right.Sources, _left.Targets);
            }
        }

        public IRoadLane[] GetLanesByDistanceTo(Vector3 position) =>
            RoadLanes.OrderBy(r => Vector3Utils.SqrDistance(r.Source.Position, position)).ToArray();
    }
}