using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.Times;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Camera
{
    public class CameraPositionSystem : DUpdateSystem
    {
        private readonly CameraBalance _cameraBalance;

        private Filter _cameraFilter;
        private Filter _userFilter;

        public CameraPositionSystem()
        {
            _cameraBalance = DiContainer.Resolve<IBalanceService>()
                .CameraBalance;
        }

        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag, PlayerInCar>();
            _cameraFilter = _world.Filter<CameraTag, Mono<ITransform>>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            Debug.Log($"a");
            
            if (_userFilter.NoOne())
                return;
            
            Debug.Log($"b");

            Entity cameraEntity = _cameraFilter.GetSingleton();
            Entity userEntity = _userFilter.GetSingleton();

            ITransform cameraTransform = cameraEntity.GetMono<ITransform>();
            
            Vector3 userCarPosition = userEntity.Get<PlayerInCar>().Car.GetMono<ITransform>().Position;

            cameraTransform.Position = (userCarPosition - cameraTransform.Rotation.GetForward() *
                _cameraBalance.CameraBackDistance).WithY(_cameraBalance.CameraHeight);
        }
    }
}