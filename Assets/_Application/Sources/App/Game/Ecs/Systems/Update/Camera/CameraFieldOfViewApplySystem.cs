using Scellecs.Morpeh;
using Sources.App.DMorpeh.MorpehUtils.Extensions;
using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.DefaultComponents.Views;
using Sources.App.Infrastructure.Services;
using Sources.App.Infrastructure.Services.Balance;
using Sources.Utils.Extensions;

namespace Sources.App.Game.Ecs.Systems.Update.Camera
{
    public class CameraFieldOfViewApplySystem : DUpdateSystem
    {
        private Filter _cameraFilter;
        private readonly CameraBalance _cameraBalance;

        public CameraFieldOfViewApplySystem()
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

            ICamera cameraData = cameraEntity.GetAccess<ICamera>();

            cameraData.FieldOfView = _cameraBalance.CameraFieldOfView;
        }
    }
}