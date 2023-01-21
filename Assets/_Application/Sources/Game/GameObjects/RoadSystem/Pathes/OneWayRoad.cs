using System.Collections.Generic;
using System.Linq;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Utilities.Extensions;
using UnityEngine;
using UnityEngine.Serialization;

namespace Sources.Game.GameObjects.RoadSystem.Pathes
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