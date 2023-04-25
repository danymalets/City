using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.ProjectServices.BalanceServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerMoveAngleCalculateSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly PlayersBalance _playersBalance;

        public PlayerMoveAngleCalculateSystem()
        {
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                float targetAngle = npcEntity.Get<PlayerTargetAngle>().Value;
                float angle = npcEntity.Get<PlayerSmoothAngle>().Value;
                ref PlayerMoveAngle playerMoveAngle = ref npcEntity.Get<PlayerMoveAngle>();

                playerMoveAngle.Value = angle;
                playerMoveAngle.Value = Mathf.MoveTowardsAngle(angle, targetAngle,
                    _playersBalance.AllowableMoveAngle);
            }
        }
    }
}