using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.GameObjects.RoadSystem;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Systems.Init
{
    public class PathSystemInitSystem : DInitializer
    {
        private ILevelContextService _levelContext;

        protected override void OnInitialize()
        {
            _levelContext = DiContainer.Resolve<ILevelContextService>();

            _world.CreateWithSingleMono<IPathSystem>(_levelContext.PathSystem);
        }
    }
}