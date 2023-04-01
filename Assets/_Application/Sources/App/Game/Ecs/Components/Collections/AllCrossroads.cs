using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Data.RoadSystem.Pathes;

namespace Sources.App.Game.Ecs.Components.Collections
{
    public struct AllCrossroads : IComponent
    {
        public List<Crossroads> List { get; set; }
    }
}