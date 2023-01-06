using Scellecs.Morpeh;
using Sources.Infrastructure.Services;
using Sources.Infrastructure.Services.AssetsManager;

namespace Sources.Game.Ecs.Factories
{
    public abstract class EcsFactory
    {
        protected readonly World _world;
        protected readonly IAssetsService _assets;

        protected EcsFactory(World world)
        {
            _world = world;
            _assets = DiContainer.Resolve<IAssetsService>();
        }
    }
}