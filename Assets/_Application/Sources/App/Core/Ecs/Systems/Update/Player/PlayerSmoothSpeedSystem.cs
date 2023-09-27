using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Player
{
    public class PlayerSmoothSpeedSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly PlayersBalance _playersBalance;

        public PlayerSmoothSpeedSystem()
        {
            _playersBalance = DiContainer.Resolve<Balance>().PlayersBalance;
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<PlayerTag>().Without<PlayerInCar>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity npcEntity in _filter)
            {
                PlayerTargetSpeed targetSpeed = npcEntity.Get<PlayerTargetSpeed>();
                ref PlayerSmoothSpeed smoothSpeed = ref npcEntity.Get<PlayerSmoothSpeed>();

                smoothSpeed.Value = Mathf.MoveTowards(smoothSpeed.Value, targetSpeed.Value,
                    deltaTime * _playersBalance.Acceleration);
            }
        }
    }
}