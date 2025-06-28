using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcCar;
using Sources.App.Core.Ecs.Data;

namespace Sources.App.Core.Ecs.Components.Car
{
    public struct TurnDecisions : IComponent
    {
        public Queue<TurnChoice> Queue { get; set; }
    }
}