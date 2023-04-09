using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Data.Cars;

namespace Sources.App.Game.Ecs.Components.NpcPathes
{
    public struct ActiveTurns : IComponent
    {
        public List<TurnData> List { get; set; }
    }
}