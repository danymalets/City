using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Systems.Init
{
    public class CameraInitSystem : DInitializer
    {
        private readonly ICameraFactory _cameraFactory;

        public CameraInitSystem()
        {
            _cameraFactory = DiContainer.Resolve<ICameraFactory>();
        }

        protected override void OnInitialize()
        {
            _cameraFactory.Create();
        }
    }
}