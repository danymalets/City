using System.Collections.Generic;
using _Application.Sources.App.Data.Cars;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Components.NpcPathes
{
    public struct ActiveTurns : IComponent
    {
        public List<TurnData> List { get; set; }
    }
}