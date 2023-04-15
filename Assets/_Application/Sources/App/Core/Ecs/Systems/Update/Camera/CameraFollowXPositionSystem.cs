using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Camera;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.ProjectServices.BalanceServices;
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