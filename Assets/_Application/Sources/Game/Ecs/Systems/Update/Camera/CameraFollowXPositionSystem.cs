using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Camera;
using Sources.Game.Ecs.Components.Player.User;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Camera
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
            
            ref var followY = ref cameraEntity.Get<CameraSmoothFollowY>();
            
            Vector3 userPosition = userEntity.Get<PlayerFollowTransform>().Position;

            followY.Value = Mathf.MoveTowards(followY.Value, userPosition.y, 
                DMath.Distance(followY.Value, userPosition.y) *
                _cameraBalance.CameraFollowYSpeedCoeff * deltaTime);
        }
    }
}