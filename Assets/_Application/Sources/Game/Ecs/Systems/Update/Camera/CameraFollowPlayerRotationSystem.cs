using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Camera;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.Physic;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Camera
{
    public class CameraFollowPlayerRotationSystem : DUpdateSystem
    {
        private readonly CameraBalance _cameraBalance;

        private Filter _cameraFilter;
        private Filter _userFilter;
        private float _now;
        private bool _st;
        private float _mx;

        public CameraFollowPlayerRotationSystem()
        {
            _cameraBalance = DiContainer.Resolve<Balance>().CameraBalance;
        }

        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag>();
            _cameraFilter = _world.Filter<CameraTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_userFilter.NoOne())
                return;

            Entity cameraEntity = _cameraFilter.GetSingleton();
            Entity userEntity = _userFilter.GetSingleton();

            ITransform cameraTransform = cameraEntity.GetMono<ITransform>();
            ref CameraYAngle cameraYAngle = ref cameraEntity.Get<CameraYAngle>();

            Quaternion userRotation = userEntity.Get<PlayerFollowTransform>().Rotation;

            float targetAngle = userRotation.eulerAngles.y;

            float signedDistance = DMath.SignedNearestAngle(targetAngle, cameraYAngle.Value);

            float distance = Mathf.Abs(signedDistance);
            float speed = (distance - _cameraBalance.DeadAngle) * _cameraBalance.CameraRotationCoeff;

            if (signedDistance > _cameraBalance.DeadAngle)
            {
                cameraYAngle.Value = Mathf.MoveTowardsAngle(cameraYAngle.Value, 
                    targetAngle + _cameraBalance.DeadAngle,
                    speed * deltaTime);
            }
            else if (signedDistance < -_cameraBalance.DeadAngle)
            {
                cameraYAngle.Value = Mathf.MoveTowardsAngle(cameraYAngle.Value, 
                    targetAngle - _cameraBalance.DeadAngle,
                    speed * deltaTime);
            }
            
            cameraTransform.Rotation = cameraTransform.Rotation.WithEulerY(cameraYAngle.Value);
        }
    }
}