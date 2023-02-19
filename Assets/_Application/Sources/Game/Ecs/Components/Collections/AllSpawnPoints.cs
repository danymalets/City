using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct AllSpawnPoints : IComponent
    {
        public List<Point> List { get; set; }
    }
}