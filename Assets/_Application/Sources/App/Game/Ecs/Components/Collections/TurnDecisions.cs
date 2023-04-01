using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Npc.NpcCar;

namespace Sources.App.Game.Ecs.Components.Collections
{
    public struct TurnDecisions : IComponent
    {
        public Queue<TurnChoice> Queue { get; set; }
    }
}