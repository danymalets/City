using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Camera;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using Sources.App.Infrastructure.Services;
using Sources.App.Infrastructure.Services.Balance;
using Sources.Utils.Extensions;

namespace Sources.App.Game.Ecs.Systems.Update.Camera
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