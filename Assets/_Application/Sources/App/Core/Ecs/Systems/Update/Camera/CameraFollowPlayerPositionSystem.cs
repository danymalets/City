using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.Camera;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Camera
{
    public class CameraFollowPlayerPositionSystem : DUpdateSystem
    {
        private readonly CameraBalance _cameraBalance;

        private Filter _cameraFilter;
        private Filter _userFilter;

        public CameraFollowPlayerPositionSystem()
        {
            _cameraBalance = DiContainer.Resolve<Balance>().CameraBalance;
        }

        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag>().Build();
            _cameraFilter = _world.Filter<CameraTag>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_cameraFilter.TryGetSingle(out Entity cameraEntity) &&
                _userFilter.TryGetSingle(out Entity userEntity))
            {
                ITransform cameraTransform = cameraEntity.GetRef<ITransform>();
                float cameraAngle = cameraEntity.Get<CameraYAngle>().Value;

                float cameraSmoothHeight = cameraEntity.Get<CameraSmoothHeight>().Value;
                float cameraSmoothBackDistance = cameraEntity.Get<CameraSmoothBackDistance>().Value;
                float smoothFollowY = cameraEntity.Get<CameraSmoothFollowY>().Value;

                Vector3 userPosition = userEntity.GetAspect<PlayerPointAspect>().GetPosition();

                Vector3 targetPosition = userPosition + Quaternion.AngleAxis(cameraAngle, Vector3.up) *
                    Vector3.back * cameraSmoothBackDistance + (smoothFollowY + cameraSmoothHeight) * Vector3.up;
                
                float distanceToTarget = Vector3.Distance(cameraTransform.Position, targetPosition);

                float delta = Mathf.Max(distanceToTarget - _cameraBalance.CameraMaxDistance, _cameraBalance.CameraSpeed * deltaTime);

                cameraTransform.Position = Vector3.MoveTowards(cameraTransform.Position, targetPosition, delta);
            }
        }
    }
}