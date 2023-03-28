using System.Collections.Generic;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Npc.NpcCar;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.NpcCar
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