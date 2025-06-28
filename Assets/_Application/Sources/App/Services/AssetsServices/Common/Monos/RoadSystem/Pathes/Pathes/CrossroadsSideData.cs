using System.Collections.Generic;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Points;

namespace Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Pathes
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