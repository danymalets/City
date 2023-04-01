using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Camera;
using Sources.App.Game.Ecs.Components.Player.User;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Di;
using Sources.DMorpeh.DefaultComponents.Views;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Services.BalanceManager;
using Sources.Utils.Extensions;
using Sources.Utils.Libs;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.Camera
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
            _cameraBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().CameraBalance;
        }

        protected override void OnConstruct()
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

            ITransform cameraTransform = cameraEntity.GetAccess<ITransform>();
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