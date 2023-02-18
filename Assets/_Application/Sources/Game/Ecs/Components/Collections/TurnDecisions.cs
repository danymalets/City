using System.Collections.Generic;
using Sources.Game.Ecs.Components.Npc.NpcCar;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct TurnDecisions : IQueueOf<TurnChoice>
    {
        public Queue<TurnChoice> Queue { get; set; }
    }
}