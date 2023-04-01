using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Camera;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Di;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Services.BalanceManager;
using Sources.Utils.Extensions;
using UnityEngine;

namespace Sources.App.Game.Ecs.Systems.Update.Camera
{
    public class CameraSmoothXAngleSystem : DUpdateSystem
    {
        private Filter _cameraFilter;
        private readonly CameraBalance _cameraBalance;

        public CameraSmoothXAngleSystem()
        {
            _cameraBalance = DiContainer.Resolve<Services.BalanceManager.Balance>().CameraBalance;
        }

        protected override void OnConstruct()
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