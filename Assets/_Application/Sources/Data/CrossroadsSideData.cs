using System.Collections.Generic;

namespace Sources.Data
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