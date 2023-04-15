using System.Collections.Generic;
using _Application.Sources.App.Core.Ecs.Components.Npc.NpcCar;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Components.Car
{
    public struct TurnDecisions : IComponent
    {
        public Queue<TurnChoice> Queue { get; set; }
    }
}