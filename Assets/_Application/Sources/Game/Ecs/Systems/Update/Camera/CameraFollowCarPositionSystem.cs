using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.Views;
using Sources.Game.Ecs.Components.Views.Transform;
using Sources.Game.Ecs.Utils;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Infrastructure.Services.Times;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Camera
{
    public class CameraFollowCarPositionSystem : DUpdateSystem
    {
        private readonly CameraBalance _cameraBalance;

        private Filter _cameraFilter;
        private Filter _userFilter;

        public CameraFollowCarPositionSystem()
        {
            _cameraBalance = DiContainer.Resolve<Balance>()
                .CameraBalance;
        }

        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag, PlayerInCar>();
            _cameraFilter = _world.Filter<CameraTag, Mono<ITransform>>();
        }

        protected override void OnUpdate(float deltaTime)
        {

            if (_userFilter.NoOne())
                return;
            
            Entity cameraEntity = _cameraFilter.GetSingleton();
            Entity userEntity = _userFilter.GetSingleton();

            ITransform cameraTransform = cameraEntity.GetMono<ITransform>();
            
            ITransform transform = userEntity.Get<PlayerInCar>().Car.GetMono<ITransform>();

            cameraTransform.Position = (transform.Position - transform.Rotation.GetForward() *
                _cameraBalance.CameraBackDistance).WithY(_cameraBalance.CameraHeight);
        }
    }
}