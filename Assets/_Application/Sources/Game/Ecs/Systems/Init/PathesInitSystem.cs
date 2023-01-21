using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Systems.Init
{
    public class PathesInitSystem : DInitializer
    {
        private readonly LevelContext _levelContext;

        public PathesInitSystem()
        {
            _levelContext = DiContainer.Resolve<LevelContext>();
        }

        protected override void OnInitialize()
        {
            _factory.CreatePathes<CarsPathesTag>(_levelContext.CarsPathSystem);
            _factory.CreatePathes<NpcsPathesTag>(_levelContext.NpcPathSystem);
        }
    }
}