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
    public class CameraSmoothDeltasSystem : DUpdateSystem
    {
        private Filter _cameraFilter;
        private readonly CameraBalance _cameraBalance;

        public CameraSmoothDeltasSystem()
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

            float cameraTargetHeight = cameraEntity.Get<CameraTargetHeight>().Value;
            float cameraTargetBackDistance = cameraEntity.Get<CameraTargetBackDistance>().Value;
            
            ref var cameraSmoothHeight = ref cameraEntity.Get<CameraSmoothHeight>();
            ref var cameraSmoothBackDistance = ref cameraEntity.Get<CameraSmoothBackDistance>();

            Vector2 newDelta = Vector2.MoveTowards(new(cameraSmoothHeight.Value, 
                    cameraSmoothBackDistance.Value),
                new Vector2(cameraTargetHeight, cameraTargetBackDistance),
                _cameraBalance.CameraDeltaSpeed * deltaTime);
            
            cameraSmoothHeight.Value = newDelta.x;
            cameraSmoothBackDistance.Value = newDelta.y;
        }
    }
}