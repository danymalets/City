using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Data.Points;

namespace Sources.App.Core.Ecs.Components.NpcPathes
{
    public struct AllPoints : IComponent
    {
        public List<Point> List { get; set; }
    }
}