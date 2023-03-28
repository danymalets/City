using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Factories;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Infrastructure.Bootstrap;
using Sources.Infrastructure.Services;

namespace Sources.Game.Ecs.Systems.Init
{
    public class PathesInitSystem : DInitializer
    {
        private readonly LevelContext _levelContext;
        private readonly IPathesFactory _pathesFactory;

        public PathesInitSystem()
        {
            _levelContext = DiContainer.Resolve<LevelContext>();
            _pathesFactory = DiContainer.Resolve<IPathesFactory>();
        }

        protected override void OnInitialize()
        {
            _pathesFactory.CreatePathes<CarsPathesTag>(_levelContext.CarsPathSystem);
            _pathesFactory.CreatePathes<NpcsPathesTag>(_levelContext.NpcPathSystem);
        }
    }
}