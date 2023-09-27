using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcCar;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcPathes;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.NpcCar
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
            _filter = _world.Filter<NpcTag, PlayerInCar, NpcOnPath>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            float reqDistance = _simulationBalance.MaxBreakingDistance +
                                _simulationBalance.CarRootToForwardPoint +
                                _simulationBalance.CarDistanceAfterBreak;

            foreach (Entity npcEntity in _filter)
            {
                Entity carEntity = npcEntity.Get<PlayerInCar>().CarPlaceData.Car;
                IWheelsSystem wheels = carEntity.GetRef<IWheelsSystem>();
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