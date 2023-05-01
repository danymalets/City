using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Npc;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class UserTargetAngleSystem : DUpdateSystem
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
            ITransform transform = userEntity.GetAccess<ITransform>();
            ref PlayerTargetAngle playerTargetAngle = ref userEntity.Get<PlayerTargetAngle>();
            
            if (userPlayerInput.MoveInput != Vector2.zero)
            {
                Vector3 input = new Vector3(userPlayerInput.MoveInput.x, 0, userPlayerInput.MoveInput.y);

                float inputAngle = Vector3.SignedAngle(Vector3.forward, input, Vector3.up);

                // чтобы при инпуте "вниз" его не дергало решая влево или вправо ему нужно
                if (DMath.Equals(Mathf.Abs(inputAngle), 180))
                {
                    inputAngle = 179f;
                }
                
                playerTargetAngle.Value = transform.Rotation.eulerAngles.y + inputAngle;
            }
            else
            {
                playerTargetAngle.Value = transform.Rotation.eulerAngles.y;
            }
        }
    }
}