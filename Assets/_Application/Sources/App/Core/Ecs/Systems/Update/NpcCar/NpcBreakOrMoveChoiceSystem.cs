using System.Collections.Generic;
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
using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.NpcCar
{
    public class NpcBreakOrMoveChoiceSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcBreakOrMoveChoiceSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath>().Without<PlayerInCar>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            float sqrReqDistance = DMath.Sqr(_simulationBalance.MaxNpcRadius + _simulationBalance.NpcDistanceAfterBreak);

            foreach (Entity npcEntity in _filter)
            {
                ITransform transform = npcEntity.GetRef<ITransform>();
                Queue<TurnChoice> choices = npcEntity.Get<TurnDecisions>().Queue;
                List<TurnData> carTurns = npcEntity.Get<ActiveTurns>().List;

                foreach (TurnChoice choiceData in choices)
                {
                    if (!choiceData.IsForceMove)
                    {
                        if (DVector3.SqrDistance(choiceData.Point.Position, 
                                transform.Position) <= sqrReqDistance)
                        {
                            if (choiceData.TurnData.IsBlocked())
                            {
                                npcEntity.Set(new PathBlockerRequest());
                            }
                            else
                            {
                                choiceData.IsForceMove = true;

                                foreach (TurnData banTurnData in choiceData.TurnData.BlockableTurns)
                                {
                                    banTurnData.IncreaseBlocked();
                                }

                                carTurns.Add(choiceData.TurnData);
                            }
                        }

                        break;
                    }
                }
            }
        }
    }
}