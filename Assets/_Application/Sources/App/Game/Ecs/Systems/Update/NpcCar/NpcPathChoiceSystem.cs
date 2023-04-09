using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Car;
using Sources.App.Game.Ecs.Components.Npc;
using Sources.App.Game.Ecs.Components.Npc.NpcCar;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Data;
using Sources.Data.Cars;
using Sources.Data.Points;
using Sources.Services.BalanceManager;
using Sources.Services.Di;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Extensions;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.NpcCar
{
    public class NpcPathChoiceSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcPathChoiceSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                float reqDistance = npcEntity.Has<PlayerInCar>()
                    ? _simulationBalance.MaxBreakingDistance +
                      _simulationBalance.CarRootToForwardPoint +
                      _simulationBalance.CarDistanceAfterBreak
                    : _simulationBalance.MaxNpcRadius + _simulationBalance.NpcDistanceAfterBreak;

                float sqrReqDistance = DMath.Sqr(reqDistance);
                
                Vector3 position = npcEntity.Get<PlayerFollowTransform>().Position;
                Queue<TurnChoice> choices = npcEntity.Get<TurnDecisions>().Queue;
                NpcOnPath npcOnPath = npcEntity.Get<NpcOnPath>();

                Point lastPoint = choices.Count == 0 ? npcOnPath.PathLine.Target : choices.Last().TurnData.FirstPathLine.Target;

                if (choices.Count == 0 || DVector3.SqrDistance(position, lastPoint.Position) < sqrReqDistance)
                {
                    TurnData selectedTurnData = lastPoint.Targets.GetRandom();
                    choices.Enqueue(new TurnChoice(lastPoint, selectedTurnData));

                    while (selectedTurnData.DependentPoint != null)
                    {
                        lastPoint = selectedTurnData.DependentPoint;
                        
                        selectedTurnData = lastPoint.Targets.GetRandom();
                        choices.Enqueue(new TurnChoice(lastPoint, selectedTurnData));
                    }
                }
            }
        }
    }
}