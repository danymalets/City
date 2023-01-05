using Leopotam.Ecs;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Factories
{
    public class CameraFactory : ICameraFactory 
    {
        private readonly ILevelContextService _levelContextService;
        private readonly EcsWorld _world;

        public CameraFactory(EcsWorld world)
        {
            _world = world;
            _levelContextService = DiContainer.Resolve<ILevelContextService>();
        }

        public EcsEntity Create()
        {
            EcsEntity cameraEntity = _world.NewEntity();

            cameraEntity.Add<CameraTag>();
            
            MonoEntity monoEntity = _levelContextService.CameraMonoEntity;
            
            monoEntity.Setup(cameraEntity);

            cameraEntity.Add<Position>();
            cameraEntity.Add<Rotation>();

            return cameraEntity;
        }
    }
}