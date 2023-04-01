using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.DMorpeh.Aspects;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.Game.Ecs.Components.Collections;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Npc.NpcCar;
using Sources.App.Game.GameObjects.RoadSystem.Pathes;
using Sources.App.Game.GameObjects.RoadSystem.Pathes.Points;

namespace Sources.App.Game.Ecs.Aspects
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