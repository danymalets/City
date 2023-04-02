using System;
using Sources.Data.MonoViews;
using Sources.Monos.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.Data
{
    [Serializable]
    public class RoadLane : IRoadLane
    {
        [SerializeField]
        private RoadLaneCheckpoint _source;
        
        [SerializeField]
        private RoadLaneCheckpoint _target;
        
        public IRoadLaneCheckpoint Source => _source;
        public IRoadLaneCheckpoint Target => _target;
    }
}