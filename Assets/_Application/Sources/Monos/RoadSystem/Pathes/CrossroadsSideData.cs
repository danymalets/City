using System.Collections.Generic;
using Sources.Monos.RoadSystem.Pathes.Points;

namespace Sources.Monos.RoadSystem.Pathes
{
    public class CrossroadsSideData
    {
        public IEnumerable<Point> Sources { get; }
        public IEnumerable<Point> Targets { get; }

        public CrossroadsSideData(IEnumerable<Point> sources, IEnumerable<Point> targets)
        {
            Sources = sources;
            Targets = targets;
        }
    }
}