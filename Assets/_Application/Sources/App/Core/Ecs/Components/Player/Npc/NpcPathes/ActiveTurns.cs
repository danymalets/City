using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Data;
using Sources.App.Services.AssetsServices.Common.Monos.RoadSystem.Pathes.Pathes;

namespace Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes
{
    public struct ActiveTurns : IComponent
    {
        public List<TurnData> List { get; set; }
    }
}