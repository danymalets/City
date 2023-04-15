using System.Collections.Generic;
using System.Linq;
using _Application.Sources.App.Core.Ecs.Components.Car;
using _Application.Sources.App.Core.Ecs.Components.Npc;
using _Application.Sources.App.Core.Ecs.Components.Npc.NpcCar;
using _Application.Sources.App.Core.Ecs.Components.NpcPathes;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.App.Data.Points;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.NpcCar
{
    public class NpcPathLineChangeSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath, NpcPointReachedEvent>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                ref NpcOnPath npcOnPath = ref npcEntity.Get<NpcOnPath>();
                List<TurnData> carTurns = npcEntity.Get<ActiveTurns>().List;
                Point reachedPoint = npcEntity.Get<NpcPointReachedEvent>().Point;
                Queue<TurnChoice> choices = npcEntity.Get<TurnDecisions>().Queue;

                TurnChoice turnChoice = choices.Dequeue();

                if (turnChoice.Point == reachedPoint)
                {
                    npcOnPath.PathLine = turnChoice.TurnData.FirstPathLine;

                    TurnData[] banTurnsToRemove = carTurns.Where(ct => ct.TargetPoint == reachedPoint).ToArray();

                    foreach (TurnData turnData in banTurnsToRemove)
                    {
                    
                        foreach (TurnData banTurn in turnData.BlockableTurns)
                        {
                            // Debug.Log($"decrease block");
                            banTurn.DecreaseBlocked();
                        }

                        carTurns.Remove(turnData);
                    }
                }
            }
        }
    }
}