using System.Collections.Generic;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.Game.GameObjects.RoadSystem.Pathes
{
    public class CrossroadsSideData
    {
        public IEnumerable<Checkpoint> Sources { get; }
        public IEnumerable<Checkpoint> Targets { get; }

        public CrossroadsSideData(IEnumerable<Checkpoint> sources, IEnumerable<Checkpoint> targets)
        {
            Sources = sources;
            Targets = targets;
        }
    }
}