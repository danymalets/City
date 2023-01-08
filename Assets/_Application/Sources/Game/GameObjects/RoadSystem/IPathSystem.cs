using System.Collections.Generic;
using Sources.Game.Ecs.Utils;
using Sources.Game.GameObjects.RoadSystem.Pathes;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.Game.GameObjects.RoadSystem
{
    public interface IPathSystem 
    {
        IEnumerable<Path> Pathes { get; }
        IEnumerable<IConnectingPoint> RootPoints { get; }
    }
}