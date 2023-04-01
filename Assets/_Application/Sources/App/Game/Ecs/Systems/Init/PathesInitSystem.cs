using Sources.App.DMorpeh.MorpehUtils.Systems;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Factories;
using Sources.App.Infrastructure.Bootstrap;
using Sources.App.Infrastructure.Services;

namespace Sources.App.Game.Ecs.Systems.Init
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