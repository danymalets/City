using System.Collections.Generic;
using System.Linq;
using _Application.Sources.App.Core.Ecs.Components.Car;
using _Application.Sources.App.Core.Ecs.Components.Npc;
using _Application.Sources.App.Core.Ecs.Components.Npc.NpcCar;
using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Data.Cars;
using _Application.Sources.App.Data.Points;
using _Application.Sources.Utils.CommonUtils.Extensions;
using _Application.Sources.Utils.CommonUtils.Libs;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using Sources.ProjectServices.BalanceServices;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.NpcCar
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