using System.Collections.Generic;
using Sources.App.Data.Points;

namespace Sources.App.Data.Pathes
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