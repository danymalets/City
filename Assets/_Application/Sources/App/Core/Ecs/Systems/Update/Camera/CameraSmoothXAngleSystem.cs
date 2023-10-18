using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Camera;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using UnityEngine;

namespace Sources.App.Core.Ecs.Systems.Update.Camera
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
            _cameraFilter = _world.Filter<CameraTag>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_cameraFilter.TryGetSingleton(out Entity cameraEntity))
            {
                float cameraTargetXAngle = cameraEntity.Get<CameraXTargetAngle>().Value;

                ref var cameraSmoothXAngle = ref cameraEntity.Get<CameraXSmoothAngle>();

                cameraSmoothXAngle.Value = Mathf.MoveTowardsAngle(cameraSmoothXAngle.Value,
                    cameraTargetXAngle, _cameraBalance.CameraXAngleSpeed);
            }
        }
    }
}