using System.Collections.Generic;
using System.Linq;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.PathSystems.Pathes
{
    public class OneWayRoad : MonoBehaviour
    {
        private const float MinLength = 5f;
        
        [SerializeField]
        private RoadLane[] _roadLanes;

        public RoadLane[] RoadLanes => _roadLanes;

        public IEnumerable<PathPoint> Sources => _roadLanes.Select(pathData => pathData.Source.RelatedPoint);
        public IEnumerable<PathPoint> Targets => _roadLanes.Select(pathData => pathData.Target.RelatedPoint);
    }
}