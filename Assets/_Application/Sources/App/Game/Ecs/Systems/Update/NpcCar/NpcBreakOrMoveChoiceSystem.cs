using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Collections;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Npc.NpcCar;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using Sources.App.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.App.Infrastructure.Services;
using Sources.App.Infrastructure.Services.Balance;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcBreakOrMoveChoiceSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcBreakOrMoveChoiceSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            float reqDistance = _simulationBalance.MaxNpcRadius + _simulationBalance.NpcDistanceAfterBreak;

            foreach (Entity npcEntity in _filter)
            {
                ITransform transform = npcEntity.GetAccess<ITransform>();
                Queue<TurnChoice> choices = npcEntity.Get<TurnDecisions>().Queue;
                List<TurnData> carTurns = npcEntity.Get<ActiveTurns>().List;

                foreach (TurnChoice choiceData in choices)
                {
                    if (!choiceData.IsForceMove)
                    {
                        if (DVector3.SqrDistance(choiceData.Point.Position, transform.Position) <=
                            DMath.Sqr(reqDistance))
                        {
                            if (choiceData.TurnData.IsBlocked())
                            {
                                _updateGizmosContext.DrawLine(transform.Position, 
                                    choiceData.Point.Position, Color.red);
                                
                                npcEntity.Set(new NpcBreakRequest());
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