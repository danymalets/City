using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Camera;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Camera
{
    public class CameraTargetDeltasSystem : DUpdateSystem
    {
        private Filter _cameraFilter;
        private readonly CameraBalance _cameraBalance;
        private Filter _userFilter;

        public CameraTargetDeltasSystem()
        {
            _cameraBalance = DiContainer.Resolve<Balance>().CameraBalance;
        }

        protected override void OnInitFilters()
        {
            _cameraFilter = _world.Filter<CameraTag>();
            _userFilter = _world.Filter<UserTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_cameraFilter.TryGetSingle(out Entity cameraEntity) &&
                _userFilter.TryGetSingle(out Entity userEntity))
            {
                ref var cameraTargetHeight = ref cameraEntity.Get<CameraTargetHeight>();
                ref var cameraTargetBackDistance = ref cameraEntity.Get<CameraTargetBackDistance>();

                cameraTargetHeight.Value =
                    userEntity.Has<PlayerInCar>() ? _cameraBalance.CameraCarHeight : _cameraBalance.CameraPlayerHeight;

                cameraTargetBackDistance.Value = userEntity.Has<PlayerInCar>()
                    ? _cameraBalance.CameraCarBackDistance
                    : _cameraBalance.CameraPlayerBackDistance;
            }
        }
    }
}