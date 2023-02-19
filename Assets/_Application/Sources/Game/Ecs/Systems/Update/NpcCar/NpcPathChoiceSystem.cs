using System.Collections.Generic;
using System.Linq;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Collections;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Npc.NpcCar;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem.Pathes.Points;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.NpcCar
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
                Queue<TurnChoice> choices = npcEntity.GetQueue<TurnDecisions, TurnChoice>();
                NpcOnPath npcOnPath = npcEntity.Get<NpcOnPath>();

                Point lastPoint = choices.Count == 0 ? npcOnPath.PathLine.Target : choices.Last().TurnData.FirstPathLine.Target;

                if (DVector3.SqrDistance(position, lastPoint.Position) < sqrReqDistance)
                {
                    choices.Enqueue(new TurnChoice(lastPoint, lastPoint.Targets.GetRandom()));
                }
            }
        }
    }
}