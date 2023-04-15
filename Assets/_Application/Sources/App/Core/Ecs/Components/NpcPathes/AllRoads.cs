using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Data.Pathes;

namespace Sources.App.Core.Ecs.Components.NpcPathes
{
    public struct AllRoads : IComponent
    {
        public List<IRoad> List { get; set; }
    }
}