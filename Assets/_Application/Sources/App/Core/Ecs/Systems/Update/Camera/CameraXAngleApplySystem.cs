using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Camera;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.App.Services.BalanceServices.CommonBalances;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Camera
{
    public class CameraXAngleApplySystem : DUpdateSystem
    {
        private Filter _cameraFilter;
        private readonly CameraBalance _cameraBalance;

        public CameraXAngleApplySystem()
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
                ITransform transform = cameraEntity.GetRef<ITransform>();
                float xAngle = cameraEntity.Get<CameraXSmoothAngle>().Value;

                transform.Rotation = transform.Rotation.WithEulerX(xAngle);
            }
        }
    }
}