using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.Camera;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.CommonUtils.Libs;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Camera
{
    public class CameraFollowXPositionSystem : DUpdateSystem
    {
        private readonly CameraBalance _cameraBalance;

        private Filter _cameraFilter;
        private Filter _userFilter;

        public CameraFollowXPositionSystem()
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
                ref var followY = ref cameraEntity.Get<CameraSmoothFollowY>();

                Vector3 userPosition = userEntity.GetAspect<PlayerPointAspect>().GetPosition();

                float distanceToTarget = DMath.Distance(userPosition.y, followY.Value);
                
                float delta = Mathf.Max(distanceToTarget - _cameraBalance.CameraMaxDistance, _cameraBalance.CameraFollowYSpeedCoeff * deltaTime);
                
                followY.Value = Mathf.MoveTowards(followY.Value, userPosition.y,
                    DMath.Distance(followY.Value, userPosition.y) *
                    delta);
            }
        }
    }
}