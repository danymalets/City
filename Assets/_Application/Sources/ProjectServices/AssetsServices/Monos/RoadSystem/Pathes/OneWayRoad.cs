using System.Collections.Generic;
using System.Linq;
using Sources.App.Data.Points;
using Sources.ProjectServices.AssetsServices.Monos.Pathes;
using UnityEngine;

namespace Sources.ProjectServices.AssetsServices.Monos.RoadSystem.Pathes
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