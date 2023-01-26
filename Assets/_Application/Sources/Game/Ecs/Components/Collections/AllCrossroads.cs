using System.Collections.Generic;
using Sources.Game.GameObjects.RoadSystem.Pathes;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct AllCrossroads : IListOf<Crossroads>
    {
        public List<Crossroads> List { get; set; }
    }
}