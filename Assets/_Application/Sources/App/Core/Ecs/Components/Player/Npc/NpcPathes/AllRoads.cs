using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Services.AssetsServices.Common.PathSystems.Pathes.Pathes;

namespace Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes
{
    public struct AllRoads : IComponent
    {
        public List<IRoad> List { get; set; }
    }
}