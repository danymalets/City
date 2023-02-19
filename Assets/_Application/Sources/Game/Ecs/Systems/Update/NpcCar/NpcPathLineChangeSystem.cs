using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Npc.NpcCar;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Utilities;
using UnityEngine.Assertions;

namespace Sources.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcPathLineChangeSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
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