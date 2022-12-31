using System.Collections.Generic;
using System.Linq;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using UnityEngine;

namespace Sources.Game.GameObjects.RoadSystem.Pathes
{
    public class SingleLaneRoad : PathGenerator
    {
        [SerializeField]
        private PathData[] _pathData;

        public override IEnumerable<Path> Generate() =>
            _pathData.Select(pathData =>
                new Path(pathData.Source, 
                    pathData.Target));

        public IEnumerable<Checkpoint> Sources => _pathData.Select(pathData => pathData.Source);
        public IEnumerable<Checkpoint> Targets => _pathData.Select(pathData => pathData.Target);
    }
}