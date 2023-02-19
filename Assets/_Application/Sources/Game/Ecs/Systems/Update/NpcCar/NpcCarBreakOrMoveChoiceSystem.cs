using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Npc.NpcCar;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views.CarEngine;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcCarBreakOrMoveChoiceSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcCarBreakOrMoveChoiceSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, PlayerInCar, NpcOnPath>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            float reqDistance = _simulationBalance.MaxBreakingDistance +
                                _simulationBalance.CarRootToForwardPoint +
                                _simulationBalance.CarDistanceAfterBreak;

            foreach (Entity npcEntity in _filter)
            {
                Entity carEntity = npcEntity.Get<PlayerInCar>().Car;
                ICarWheels wheels = carEntity.GetMono<ICarWheels>();
                Queue<TurnChoice> choices = npcEntity.Get<TurnDecisions>().Queue;
                List<TurnData> npcTurns = npcEntity.Get<ActiveTurns>().List;
                
                foreach (TurnChoice choiceData in choices)
                {
                    if (!choiceData.IsForceMove)
                    {
                        if (DVector3.SqrDistance(choiceData.Point.Position, wheels.RootPosition) <=
                            DMath.Sqr(reqDistance))
                        {
                            TurnChoice[] turnChoices = GetThisAndAllDependentChoices(choiceData, choices).ToArray();

                            if (turnChoices.Any(ch => ch.TurnData.IsBlocked()))
                            {
                                npcEntity.Set(new NpcCarBreakRequest { Point = choiceData.Point });
                            }
                            else
                            {
                                foreach (TurnChoice turnChoice in turnChoices)
                                {
                                    ForceMove(npcTurns, turnChoice);
                                }
                            }
                        }
                        
                        break;
                    }
                }
            }
        }

        private static IEnumerable<TurnChoice> GetThisAndAllDependentChoices
            (TurnChoice choice, Queue<TurnChoice> choices)
        {
            TurnChoice tempChoice = choice;
            
            yield return tempChoice;
            
            while (tempChoice.TurnData.DependentPoint != null)
            {
                tempChoice = choices
                    .First(ch => ch.Point ==
                                 tempChoice.TurnData.DependentPoint);
             
                yield return tempChoice;
            }
        }

        private static void ForceMove(List<TurnData> npcTurns, TurnChoice choiceData)
        {
            choiceData.IsForceMove = true;
            foreach (TurnData banTurnData in choiceData.TurnData.BlockableTurns)
            {
                banTurnData.IncreaseBlocked();
            }
            npcTurns.Add(choiceData.TurnData);
        }
    }
}