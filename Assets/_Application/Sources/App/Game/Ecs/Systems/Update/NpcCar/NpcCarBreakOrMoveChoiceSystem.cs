using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Collections;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Npc.NpcCar;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Monos.RoadSystem.Pathes.Points;
using Sources.MonoViews.MonoViews;
using Sources.Services.BalanceManager;
using Sources.Services.Di;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Libs;

namespace Sources.App.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcCarBreakOrMoveChoiceSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcCarBreakOrMoveChoiceSystem()
        {
            _simulationBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().SimulationBalance;
        }

        protected override void OnConstruct()
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
                IWheelsSystem wheels = carEntity.GetAccess<IWheelsSystem>();
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