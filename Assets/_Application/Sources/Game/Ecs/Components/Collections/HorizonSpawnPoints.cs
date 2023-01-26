using System.Collections.Generic;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct HorizonSpawnPoints : IListOf<Point>
    {
        public List<Point> List { get; set; }
    }
}