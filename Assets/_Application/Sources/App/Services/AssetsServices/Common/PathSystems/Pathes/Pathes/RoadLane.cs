using System;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes
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