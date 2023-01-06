using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Factories
{
    public class CameraFactory : EcsFactory, ICameraFactory 
    {
        private readonly ILevelContextService _levelContextService;

        public CameraFactory(World world) : base(world)
        {          
            _levelContextService = DiContainer.Resolve<ILevelContextService>();
        }

        public Entity Create()
        {
            Entity cameraEntity = _world.CreateFromMono(_levelContextService.CameraMonoEntity)
                .Add<CameraTag>();
            return cameraEntity;
        }
    }
}