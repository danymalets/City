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
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Camera
{
    public class CameraFollowPlayerRotationSystem : DUpdateSystem
    {
        private readonly CameraBalance _cameraBalance;

        private Filter _cameraFilter;
        private Filter _userFilter;

        public CameraFollowPlayerRotationSystem()
        {
            _cameraBalance = DiContainer.Resolve<Balance>()
                .CameraBalance;
        }
        
        protected override void OnInitFilters()
        {
            _userFilter = _world.Filter<UserTag>().Without<PlayerInCar>();
            _cameraFilter = _world.Filter<CameraTag, Mono<ITransform>>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_userFilter.NoOne())
                return;

            Entity cameraEntity = _cameraFilter.GetSingleton();
            Entity userEntity = _userFilter.GetSingleton();

            ITransform cameraTransform = cameraEntity.GetMono<ITransform>();
            
            Quaternion userRotation = userEntity.GetMono<ITransform>().Rotation;

            cameraTransform.Rotation = cameraTransform.Rotation.WithEulerY(userRotation.eulerAngles.y);
        }
    }
}