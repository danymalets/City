using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Factories;
using Sources.App.Infrastructure.Services;

namespace Sources.App.Game.Ecs.Systems.Init
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