using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Camera;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.Di;
using Sources.DMorpeh.DefaultComponents.Views;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Services.BalanceManager;
using Sources.Utils.Extensions;

namespace Sources.App.Game.Ecs.Systems.Update.Camera
{
    public class CameraXAngleApplySystem : DUpdateSystem
    {
        private Filter _cameraFilter;
        private readonly CameraBalance _cameraBalance;

        public CameraXAngleApplySystem()
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

            ITransform transform = cameraEntity.GetAccess<ITransform>();
            float xAngle = cameraEntity.Get<CameraXSmoothAngle>().Value;

            transform.Rotation = transform.Rotation.WithEulerX(xAngle);
        }
    }
}