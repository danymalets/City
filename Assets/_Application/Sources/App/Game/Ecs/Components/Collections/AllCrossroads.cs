using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Game.GameObjects.RoadSystem.Pathes;

namespace Sources.App.Game.Ecs.Components.Collections
{
    public struct AllCrossroads : IComponent
    {
        public List<Crossroads> List { get; set; }
    }
}