using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.ProjectServices.BalanceServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class UserTargetAngleAndSpeedSystem : DUpdateSystem
    {
        private const float MaxInputAngle = 90;

        private Filter _filter;
        private readonly PlayersBalance _playerBalance;

        public UserTargetAngleAndSpeedSystem()
        {
            _playerBalance = DiContainer.Resolve<Balance>().PlayersBalance;
        }

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
            ITransform transform = userEntity.GetAccess<ITransform>();
            ref PlayerTargetAngle playerTargetAngle = ref userEntity.Get<PlayerTargetAngle>();
            ref RotationSpeed rotationSpeed = ref userEntity.Get<RotationSpeed>();

            Vector3 input = new Vector3(userPlayerInput.MoveInput.x, 0, userPlayerInput.MoveInput.y);

            if (userPlayerInput.MoveInput != Vector2.zero)
            {
                float inputAngle = Vector3.SignedAngle(Vector3.forward, input, Vector3.up);

                rotationSpeed.Value = Mathf.Min(Mathf.Abs(inputAngle), MaxInputAngle) *
                    _playerBalance.MaxRotationSpeed / MaxInputAngle;

                if (DMath.Equals(Mathf.Abs(inputAngle), 180))
                {
                    inputAngle = 179f;
                }

                playerTargetAngle.Value = transform.Rotation.eulerAngles.y + inputAngle;
            }
            else
            {
                rotationSpeed.Value = 0;
                playerTargetAngle.Value = transform.Rotation.eulerAngles.y;
            }
            
            // Debug.Log($"rotspeed {rotationSpeed.Value}");
        }
    }
}