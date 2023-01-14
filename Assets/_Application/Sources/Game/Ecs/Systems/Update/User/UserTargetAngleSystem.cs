using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Npc;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.PlayerDatas;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.User
{
    public class UserTargetAngleSystem : DUpdateSystem
    {      
        private const float MaxInputAngle = 90;

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
            ITransform transform = userEntity.GetMono<ITransform>();
            IPlayerData playerData = userEntity.GetMono<IPlayerData>();
            ref TargetAngle targetAngle = ref userEntity.Get<TargetAngle>();
            ref RotationSpeed rotationSpeed = ref userEntity.Get<RotationSpeed>();

            Vector2 direction = new(userPlayerInput.Horizontal, userPlayerInput.Vertical);

            Vector3 input = new Vector3(userPlayerInput.Horizontal, 0, userPlayerInput.Vertical);
            
            if (direction != Vector2.zero)
            {
                float inputAngle = Vector3.SignedAngle(Vector3.forward, input, Vector3.up);

                rotationSpeed.Value = Mathf.Min(Mathf.Abs(inputAngle), MaxInputAngle) *
                    playerData.MaxRotationSpeed / MaxInputAngle;

                Debug.Log($"angle {Mathf.Abs(inputAngle)}");

                if (DMath.Equals(Mathf.Abs(inputAngle), 180))
                {
                    inputAngle = 179f;
                }
                
                targetAngle.Value = transform.Rotation.eulerAngles.y + inputAngle;
            }
            else
            {
                targetAngle.Value = transform.Rotation.eulerAngles.y;
            }
        }
    }
}