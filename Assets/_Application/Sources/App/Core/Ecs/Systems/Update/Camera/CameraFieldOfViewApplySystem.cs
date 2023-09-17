using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Services.BalanceServices;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.DefaultComponents.Views;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.Camera
{
    public class CameraFieldOfViewApplySystem : DUpdateSystem
    {
        private Filter _cameraFilter;
        private readonly CameraBalance _cameraBalance;

        public CameraFieldOfViewApplySystem()
        {
            _cameraBalance = DiContainer.Resolve<Balance>().CameraBalance;
        }

        protected override void OnInitFilters()
        {
            _cameraFilter = _world.Filter<CameraTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_cameraFilter.TryGetSingle(out Entity cameraEntity))
            {
                ICamera cameraData = cameraEntity.GetRef<ICamera>();

                cameraData.FieldOfView = _cameraBalance.CameraFieldOfView;
            }
        }
    }
}