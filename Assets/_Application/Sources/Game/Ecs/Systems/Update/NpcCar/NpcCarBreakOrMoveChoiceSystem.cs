using System.Collections.Generic;
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
                Queue<ChoiceData> choices = npcEntity.GetQueue<PredictedChoices, ChoiceData>();
                List<TurnData> npcTurns = npcEntity.GetList<ActiveTurns, TurnData>();

                foreach (ChoiceData choiceData in choices)
                {
                    if (!choiceData.IsForceMove && 
                        DVector3.SqrDistance(choiceData.Point.Position, wheels.RootPosition) <=
                        DMath.Sqr(reqDistance))
                    {
                        if (choiceData.TurnData.IsBlocked())
                        {
                            npcEntity.Set(new NpcCarBreakRequest { Point = choiceData.Point });
                        }
                        else
                        {
                            choiceData.IsForceMove = true;
                            foreach (TurnData banTurnData in choiceData.TurnData.BlockableTurns)
                            {
                                banTurnData.IncreaseBlocked();
                            }
                            
                            if (choiceData.TurnData.TargetPoint != null)
                                npcTurns.Add(choiceData.TurnData);
                        }
                    }
                }
            }
        }
    }
}