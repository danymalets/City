using System.Collections.Generic;
using Sources.Game.GameObjects.RoadSystem.Pathes;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct AllRoads : IListOf<Road>
    {
        public List<Road> List { get; set; }
    }
}