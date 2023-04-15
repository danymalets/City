using System.Collections.Generic;
using _Application.Sources.App.Core.Ecs.Components.Car;
using _Application.Sources.App.Core.Ecs.Components.Npc;
using _Application.Sources.App.Core.Ecs.Components.Npc.NpcCar;
using _Application.Sources.App.Core.Ecs.Components.NpcPathes;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.App.Data.Pathes;
using _Application.Sources.Utils.MorpehWrapper.Aspects;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Aspects
{
    public struct NpcStatusAspect : IDAspect
    {
        public Entity Entity { get; set; }

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