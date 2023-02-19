using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.GameObjects.RoadSystem.Pathes;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct AllRoads : IComponent
    {
        public List<Road> List { get; set; }
    }
}