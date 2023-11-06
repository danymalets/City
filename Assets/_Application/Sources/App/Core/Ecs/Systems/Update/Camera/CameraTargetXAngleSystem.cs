using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Camera;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Camera
{
    public class CameraTargetXAngleSystem : DUpdateSystem
    {
        private Filter _cameraFilter;
        private readonly CameraBalance _cameraBalance;
        private Filter _userFilter;

        public CameraTargetXAngleSystem()
        {
            _cameraBalance = DiContainer.Resolve<Balance>().CameraBalance;
        }

        protected override void OnInitFilters()
        {
            _cameraFilter = _world.Filter<CameraTag>().Build();
            _userFilter = _world.Filter<UserTag>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_cameraFilter.TryGetSingleton(out Entity cameraEntity) &&
                _userFilter.TryGetSingleton(out Entity userEntity))
            {
                ref var cameraTargetXAngle = ref cameraEntity.Get<CameraXTargetAngle>();

                cameraTargetXAngle.Value = userEntity.Has<PlayerInCar>()
                    ? _cameraBalance.CameraCarXRotationAngle
                    : _cameraBalance.CameraPlayerXRotationAngle;
            }
        }
    }
}