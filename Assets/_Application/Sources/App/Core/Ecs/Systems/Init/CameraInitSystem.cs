using Sources.App.Core.Ecs.Factories;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Init
{
    public class CameraInitSystem : CustomInitializer
    {
        private readonly ICamerasFactory _cameraFactory;

        public CameraInitSystem()
        {
            _cameraFactory = DiContainer.Resolve<ICamerasFactory>();
        }

        protected override void OnInitialize()
        {
            _cameraFactory.CreateCamera();
            _cameraFactory.CreateSimulationCamera();
        }
    }
}