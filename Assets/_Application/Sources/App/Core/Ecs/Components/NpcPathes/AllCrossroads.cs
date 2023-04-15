using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Data.Pathes;

namespace Sources.App.Core.Ecs.Components.NpcPathes
{
    public struct AllCrossroads : IComponent
    {
        public List<ICrossroads> List { get; set; }
    }
}