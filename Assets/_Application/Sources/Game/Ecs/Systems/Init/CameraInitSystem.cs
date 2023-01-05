using Leopotam.Ecs;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Utils;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Systems.Init
{
    public class CameraInitSystem : IEcsInitSystem
    {
        private readonly EcsWorld _world;
        private readonly CameraFactory _cameraFactory;
        private readonly ILevelContextService _levelContext;

        public CameraInitSystem()
        {
            _levelContext = DiContainer.Resolve<ILevelContextService>();
        }

        public void Init()
        {
            _cameraFactory.Create();
        }
    }
}