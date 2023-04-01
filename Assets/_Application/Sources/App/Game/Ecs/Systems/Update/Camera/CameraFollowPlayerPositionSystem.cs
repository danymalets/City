using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Camera;
using Sources.App.Game.Ecs.Components.Player.User;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Di;
using Sources.DMorpeh.DefaultComponents.Views;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Services.BalanceManager;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.Camera
{
    public class CameraFollowPlayerPositionSystem : DUpdateSystem
    {
        private readonly CameraBalance _cameraBalance;

        private Filter _cameraFilter;
        private Filter _userFilter;

        public CameraFollowPlayerPositionSystem()
        {
            _cameraBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().CameraBalance;
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

            ITransform cameraTransform = cameraEntity.GetAccess<ITransform>();
            float cameraAngle = cameraEntity.Get<CameraYAngle>().Value;
            
            float cameraSmoothHeight = cameraEntity.Get<CameraSmoothHeight>().Value;
            float cameraSmoothBackDistance = cameraEntity.Get<CameraSmoothBackDistance>().Value;
            float smoothFollowY = cameraEntity.Get<CameraSmoothFollowY>().Value;

            Vector3 userPosition = userEntity.Get<PlayerFollowTransform>().Position;
            
            Vector3 targetPosition = userPosition + Quaternion.AngleAxis(cameraAngle, Vector3.up) *
                Vector3.back * cameraSmoothBackDistance + (smoothFollowY + cameraSmoothHeight) * Vector3.up;

            cameraTransform.Position = Vector3.MoveTowards(cameraTransform.Position, targetPosition,
                _cameraBalance.CameraSpeed * deltaTime);
        }
    }
}