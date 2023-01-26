using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Player.User;
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
    public class CameraFollowPlayerPositionSystem : DUpdateSystem
    {
        private readonly CameraBalance _cameraBalance;

        private Filter _cameraFilter;
        private Filter _userFilter;

        public CameraFollowPlayerPositionSystem()
        {
            _cameraBalance = DiContainer.Resolve<Balance>()
                .CameraBalance;
        }

        protected override void OnInitFilters()
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

            ITransform cameraTransform = cameraEntity.GetMono<ITransform>();
            
            Vector3 userPosition = userEntity.Get<UserFollowTransform>().Position;

            cameraTransform.Position = (userPosition - cameraTransform.Rotation.GetForward() *
                _cameraBalance.CameraBackDistance).WithY(_cameraBalance.CameraHeight);
        }
    }
}