using System;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Pathes;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.App.Services.AssetsServices.Common.Monos.Pathes
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