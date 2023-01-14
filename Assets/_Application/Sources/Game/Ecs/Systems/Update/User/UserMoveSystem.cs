using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Components.Views.PlayerDatas;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.User
{
    public class UserMoveSystem : DUpdateSystem
    {
        private Filter _filter;

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<UserTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_filter.NoOne())
                return;

            Entity userEntity = _filter.GetSingleton();
            
            UserPlayerInput userPlayerInput = userEntity.Get<UserPlayerInput>();
            IPlayerData playerData = userEntity.GetMono<IPlayerData>();
            ref PlayerSpeed playerSpeed = ref userEntity.Get<PlayerSpeed>();

            Vector2 direction = new(userPlayerInput.Horizontal, userPlayerInput.Vertical);

            Debug.Log($"dir {direction}");
            
            if (direction == Vector2.zero)
            {
                playerSpeed.Value = 0;
            }
            else
            {
                playerSpeed.Value = playerData.Speed;
            }
        }
    }
}