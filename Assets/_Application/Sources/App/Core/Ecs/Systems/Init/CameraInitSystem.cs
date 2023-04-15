using _Application.Sources.App.Core.Ecs.Factories;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace _Application.Sources.App.Core.Ecs.Systems.Init
{
    public class CameraInitSystem : DInitializer
    {
        private readonly ICamerasFactory _cameraFactory;

        public CameraInitSystem()
        {
            _cameraFactory = DiContainer.Resolve<ICamerasFactory>();
        }

        protected override void OnInitialize()
        {
            _cameraFactory.CreateCamera();
        }
    }
}