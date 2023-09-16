using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Data.Cars;

namespace Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes
{
    public struct ActiveTurns : IComponent
    {
        public List<TurnData> List { get; set; }
    }
}