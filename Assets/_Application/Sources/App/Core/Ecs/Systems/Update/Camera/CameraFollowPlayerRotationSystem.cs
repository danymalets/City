using _Application.Sources.App.Core.Ecs.Components.Camera;
using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.Utils.CommonUtils.Extensions;
using _Application.Sources.Utils.CommonUtils.Libs;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;
using Sources.ProjectServices.BalanceServices;
using UnityEngine;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.Camera
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