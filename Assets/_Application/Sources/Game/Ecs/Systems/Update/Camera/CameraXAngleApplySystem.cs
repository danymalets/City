using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Camera;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.DefaultComponents;
using Sources.Game.Ecs.DefaultComponents.Views;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.Balance;
using Sources.Utilities.Extensions;

namespace Sources.Game.Ecs.Systems.Update.Camera
{
    public class CameraXAngleApplySystem : DUpdateSystem
    {
        private Filter _cameraFilter;
        private readonly CameraBalance _cameraBalance;

        public CameraXAngleApplySystem()
        {
            _cameraBalance = DiContainer.Resolve<Balance>().CameraBalance;
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

            ITransform transform = cameraEntity.GetAccess<ITransform>();
            float xAngle = cameraEntity.Get<CameraXSmoothAngle>().Value;

            transform.Rotation = transform.Rotation.WithEulerX(xAngle);
        }
    }
}