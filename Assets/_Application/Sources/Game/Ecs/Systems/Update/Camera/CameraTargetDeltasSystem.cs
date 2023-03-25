using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Camera;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities.Extensions;

namespace Sources.Game.Ecs.Systems.Update.Camera
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

        protected override void OnConstruct()
        {
            _cameraFilter = _world.Filter<CameraTag>();
            _userFilter = _world.Filter<UserTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_cameraFilter.NoOne())
                return;
            
            Entity cameraEntity = _cameraFilter.GetSingleton();
            Entity userEntity = _userFilter.GetSingleton();

            ref var cameraTargetHeight = ref cameraEntity.Get<CameraTargetHeight>();
            ref var cameraTargetBackDistance = ref cameraEntity.Get<CameraTargetBackDistance>();

            cameraTargetHeight.Value = userEntity.Has<PlayerInCar>() ? 
                _cameraBalance.CameraCarHeight : _cameraBalance.CameraPlayerHeight;
            
            cameraTargetBackDistance.Value = userEntity.Has<PlayerInCar>() ? 
                _cameraBalance.CameraCarBackDistance : _cameraBalance.CameraPlayerBackDistance;
        }
    }
}