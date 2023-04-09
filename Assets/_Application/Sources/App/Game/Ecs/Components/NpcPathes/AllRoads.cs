using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Data.Pathes;

namespace Sources.App.Game.Ecs.Components.NpcPathes
{
    public struct AllRoads : IComponent
    {
        public List<IRoad> List { get; set; }
    }
}