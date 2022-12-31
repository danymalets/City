using System;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes
{
    [Serializable]
    public class PathData
    {
        [SerializeField]
        private Checkpoint _source;
        
        [SerializeField]
        private Checkpoint _target;
        
        public Checkpoint Source => _source;
        public Checkpoint Target => _target;
    }
}