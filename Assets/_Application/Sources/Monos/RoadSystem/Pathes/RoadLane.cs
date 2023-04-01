using System;
using Sources.Monos.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.Monos.RoadSystem.Pathes
{
    [Serializable]
    public class RoadLane
    {
        [SerializeField]
        private RoadLaneCheckpoint _source;
        
        [SerializeField]
        private RoadLaneCheckpoint _target;
        
        public RoadLaneCheckpoint Source => _source;
        public RoadLaneCheckpoint Target => _target;
    }
}