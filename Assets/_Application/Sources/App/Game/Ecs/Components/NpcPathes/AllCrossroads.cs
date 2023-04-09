using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Data.Pathes;

namespace Sources.App.Game.Ecs.Components.NpcPathes
{
    public struct AllCrossroads : IComponent
    {
        public List<ICrossroads> List { get; set; }
    }
}