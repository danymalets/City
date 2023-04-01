using System.Collections.Generic;
using Sources.App.Game.GameObjects.RoadSystem.Pathes;

namespace Sources.App.Game.GameObjects.RoadSystem
{
    public interface IPathSystem 
    {
        IEnumerable<PathLine> Pathes { get; }
        IEnumerable<Road> Roads { get; }
        IEnumerable<Crossroads> Crossroads { get; }
    }
}