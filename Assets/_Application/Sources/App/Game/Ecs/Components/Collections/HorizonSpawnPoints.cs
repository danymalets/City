using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.App.Game.Ecs.Components.Collections
{
    public struct HorizonSpawnPoints : IComponent
    {
        public List<Point> List { get; set; }
    }
}