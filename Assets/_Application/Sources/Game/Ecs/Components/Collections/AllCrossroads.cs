using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.GameObjects.RoadSystem.Pathes;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct AllCrossroads : IComponent
    {
        public List<Crossroads> List { get; set; }
    }
}