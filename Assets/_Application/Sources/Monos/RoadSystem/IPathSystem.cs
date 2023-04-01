using System.Collections.Generic;
using Sources.Data.RoadSystem.Pathes;

namespace Sources.Data.RoadSystem
{
    public interface IPathSystem 
    {
        IEnumerable<PathLine> Pathes { get; }
        IEnumerable<Road> Roads { get; }
        IEnumerable<Crossroads> Crossroads { get; }
    }
}