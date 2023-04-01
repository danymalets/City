using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Components.User;
using Sources.Di;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Services.BalanceManager;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.User
{
    public class UserMoveSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly PlayersBalance _playersBalance;

        public UserMoveSystem()
        {
            _playersBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().PlayersBalance;
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<UserTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_filter.NoOne())
                return;

            Entity userEntity = _filter.GetSingleton();

            UserPlayerInput userPlayerInput = userEntity.Get<UserPlayerInput>();
            ref PlayerTargetSpeed playerTargetSpeed = ref userEntity.Get<PlayerTargetSpeed>();
            
            playerTargetSpeed.Value = _playersBalance.UserMaxSpeed * userPlayerInput.MoveInput.magnitude * 
                                      Vector2.Angle(Vector2.down, userPlayerInput.MoveInput) / 180f;
        }
    }
}