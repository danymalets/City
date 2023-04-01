using System.Collections.Generic;
using System.Linq;
using Sources.Data.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.Data.RoadSystem.Pathes
{
    public class OneWayRoad : MonoBehaviour
    {
        private const float MinLength = 5f;
        
        [SerializeField]
        private RoadLane[] _roadLanes;

        public RoadLane[] RoadLanes => _roadLanes;

        public IEnumerable<Point> Sources => _roadLanes.Select(pathData => pathData.Source.RelatedPoint);
        public IEnumerable<Point> Targets => _roadLanes.Select(pathData => pathData.Target.RelatedPoint);
    }
}