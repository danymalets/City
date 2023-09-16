using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcCar;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Data.Pathes;
using Sources.Utils.MorpehWrapper.Aspects;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;

namespace Sources.App.Core.Ecs.Aspects.Player
{
    public struct NpcStatusAspect : IDAspect
    {
        public Entity Entity { get; set; }

        public Filter GetFilter(Filter filter) =>
            filter.With<PlayerTag>();

        public readonly bool IsOnPath => Entity.Has<NpcOnPath>();

        public readonly void SetPath(PathLine pathLine)
        {
            Entity.Set(new NpcOnPath { PathLine = pathLine })
                .Set(new ActiveTurns { List = new List<TurnData>() })
                .Set(new TurnDecisions { Queue = new Queue<TurnChoice>() });
        }
        
        public readonly void LeavePath()
        {
            List<TurnData> activeTurns = Entity.Get<ActiveTurns>().List;
            
            foreach (TurnData activeTurn in activeTurns)
            {
                foreach (TurnData blockedTurn in activeTurn.BlockableTurns)
                {
                    blockedTurn.DecreaseBlocked();
                }
            }
         
            Entity.Remove<NpcOnPath>();
            Entity.Remove<ActiveTurns>();
            Entity.Remove<TurnDecisions>();
        }

        public readonly void LeaveIfOnPath()
        {
            if (IsOnPath)
                LeavePath();
        }
    }
}