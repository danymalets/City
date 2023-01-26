using System.Collections.Generic;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct AllSpawnPoints : IListOf<Point>
    {
        public List<Point> List { get; set; }
    }
}