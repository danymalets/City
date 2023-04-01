using System;
using Sources.App.Game.GameObjects.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.App.Game.GameObjects.RoadSystem.Pathes
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