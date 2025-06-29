using System.Collections.Generic;

namespace Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes
{
    public class CrossroadsSideData
    {
        public IEnumerable<PathPoint> Sources { get; }
        public IEnumerable<PathPoint> Targets { get; }

        public CrossroadsSideData(IEnumerable<PathPoint> sources, IEnumerable<PathPoint> targets)
        {
            Sources = sources;
            Targets = targets;
        }
    }
}