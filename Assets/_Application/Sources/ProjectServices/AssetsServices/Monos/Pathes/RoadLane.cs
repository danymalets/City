using System;
using Sources.App.Data.Pathes;
using Sources.ProjectServices.AssetsServices.Monos.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.ProjectServices.AssetsServices.Monos.Pathes
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