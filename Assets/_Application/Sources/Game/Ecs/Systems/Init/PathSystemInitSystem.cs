using Sources.Game.Ecs.Utils.MorpehWrapper;
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

            _world.CreateFromMono(_levelContext.PathSystemEntity);
        }
    }
}