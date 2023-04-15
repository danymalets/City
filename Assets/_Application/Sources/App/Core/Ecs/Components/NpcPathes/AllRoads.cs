using System.Collections.Generic;
using _Application.Sources.App.Data.Pathes;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Components.NpcPathes
{
    public struct AllRoads : IComponent
    {
        public List<IRoad> List { get; set; }
    }
}