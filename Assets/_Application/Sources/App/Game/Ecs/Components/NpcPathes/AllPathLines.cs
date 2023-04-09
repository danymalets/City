using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Data.Pathes;

namespace Sources.App.Game.Ecs.Components.NpcPathes
{
    public struct AllPathLines : IComponent
    {
        public List<PathLine> List { get; set; }
    }
}