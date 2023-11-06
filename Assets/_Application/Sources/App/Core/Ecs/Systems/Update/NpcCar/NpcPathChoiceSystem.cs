using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.Car;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Player.Npc.NpcCar;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Data.Points;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.NpcCar
{
    public class NpcPathChoiceSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly SimulationBalance _simulationBalance;

        public NpcPathChoiceSystem()
        {
            _simulationBalance = DiContainer.Resolve<Balance>().SimulationBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<NpcTag, NpcOnPath>().Build();
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
                
                Vector3 position = npcEntity.GetAspect<PlayerPointAspect>().GetPosition();
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