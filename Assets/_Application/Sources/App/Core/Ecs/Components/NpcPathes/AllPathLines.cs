using System.Collections.Generic;
using _Application.Sources.App.Data.Pathes;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Components.NpcPathes
{
    public struct AllPathLines : IComponent
    {
        public List<PathLine> List { get; set; }
    }
}