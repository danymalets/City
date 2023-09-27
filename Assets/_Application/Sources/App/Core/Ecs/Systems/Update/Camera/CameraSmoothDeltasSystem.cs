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
    public class CameraSmoothDeltasSystem : DUpdateSystem
    {
        private Filter _cameraFilter;
        private readonly CameraBalance _cameraBalance;

        public CameraSmoothDeltasSystem()
        {
            _cameraBalance = DiContainer.Resolve<Balance>().CameraBalance;
        }

        protected override void OnInitFilters()
        {
            _cameraFilter = _world.Filter<CameraTag>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_cameraFilter.TryGetSingle(out Entity cameraEntity))
            {
                float cameraTargetHeight = cameraEntity.Get<CameraTargetHeight>().Value;
                float cameraTargetBackDistance = cameraEntity.Get<CameraTargetBackDistance>().Value;

                ref var cameraSmoothHeight = ref cameraEntity.Get<CameraSmoothHeight>();
                ref var cameraSmoothBackDistance = ref cameraEntity.Get<CameraSmoothBackDistance>();

                Vector2 newDelta = Vector2.MoveTowards(new Vector2(cameraSmoothHeight.Value,
                        cameraSmoothBackDistance.Value),
                    new Vector2(cameraTargetHeight, cameraTargetBackDistance),
                    _cameraBalance.CameraDeltaSpeed * deltaTime);

                cameraSmoothHeight.Value = newDelta.x;
                cameraSmoothBackDistance.Value = newDelta.y;
            }
        }
    }
}