using Scellecs.Morpeh;
using Sources.Game.Ecs.Factories;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Utils.MorpehWrapper
{
    public abstract class DSystem
    {
        protected World _world;
        protected IFactory _factory;

        public void Setup(World world)
        {
            _world = world;
            _factory = DiContainer.Resolve<IFactory>();
        }
    }
}