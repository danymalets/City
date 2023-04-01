using System.Collections.Generic;
using Sources.Monos.RoadSystem.Pathes;

namespace Sources.Monos.RoadSystem
{
    public interface IPathSystem 
    {
        IEnumerable<PathLine> Pathes { get; }
        IEnumerable<Road> Roads { get; }
        IEnumerable<Crossroads> Crossroads { get; }
    }
}