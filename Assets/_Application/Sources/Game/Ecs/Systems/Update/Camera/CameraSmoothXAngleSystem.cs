using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Camera;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update.Camera
{
    public class CameraSmoothXAngleSystem : DUpdateSystem
    {
        private Filter _cameraFilter;
        private readonly CameraBalance _cameraBalance;

        public CameraSmoothXAngleSystem()
        {
            _cameraBalance = DiContainer.Resolve<Balance>().CameraBalance;
        }

        protected override void OnInitFilters()
        {
            _cameraFilter = _world.Filter<CameraTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_cameraFilter.NoOne())
                return;
            
            Entity cameraEntity = _cameraFilter.GetSingleton();

            float cameraTargetXAngle = cameraEntity.Get<CameraXTargetAngle>().Value;
            
            ref var cameraSmoothXAngle = ref cameraEntity.Get<CameraXSmoothAngle>();
            
            cameraSmoothXAngle.Value = Mathf.MoveTowardsAngle(cameraSmoothXAngle.Value, 
                cameraTargetXAngle, _cameraBalance.CameraXAngleSpeed);
        }
    }
}