using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Data.Pathes;

namespace Sources.App.Core.Ecs.Components.NpcPathes
{
    public struct AllPathLines : IComponent
    {
        public List<PathLine> List { get; set; }
    }
}