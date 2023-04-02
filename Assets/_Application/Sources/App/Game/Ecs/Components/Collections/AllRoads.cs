using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Data.MonoViews;

namespace Sources.App.Game.Ecs.Components.Collections
{
    public struct AllRoads : IComponent
    {
        public List<IRoad> List { get; set; }
    }
}