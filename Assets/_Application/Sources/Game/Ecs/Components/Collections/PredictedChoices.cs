using System.Collections.Generic;
using Sources.Game.Ecs.Components.Npc.NpcCar;

namespace Sources.Game.Ecs.Components.Collections
{
    public struct PredictedChoices : IQueueOf<ChoiceData>
    {
        public Queue<ChoiceData> Queue { get; set; }
    }
}