using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.NavPathes;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.Npc;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
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
            _filter = _world.Filter<PlayerTag>().Without<PlayerInCar>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity playerEntity in _filter)
            {
                float targetAngle = playerEntity.Get<PlayerTargetAngle>().Value;
                float angle = playerEntity.Get<PlayerSmoothAngle>().Value;
                ref PlayerMoveAngle playerMoveAngle = ref playerEntity.Get<PlayerMoveAngle>();

                playerMoveAngle.Value = Mathf.MoveTowardsAngle(angle, targetAngle,
                    playerEntity.Has<PLayerOnNavPath>() ?
                        _playersBalance.NavAllowableMoveAngle :
                        _playersBalance.AllowableMoveAngle);
            }
        }
    }
}