using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Data;

namespace Sources.App.Game.Ecs.Components.Collections
{
    public struct ActiveTurns : IComponent
    {
        public List<TurnData> List { get; set; }
    }
}