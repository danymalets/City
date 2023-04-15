using System.Collections.Generic;
using Sources.Data.Points;

namespace Sources.Data.Pathes
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