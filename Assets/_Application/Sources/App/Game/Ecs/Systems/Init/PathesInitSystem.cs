using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Factories;
using Sources.Data.MonoViews;
using Sources.Monos;
using Sources.Services.Di;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;

namespace Sources.App.Game.Ecs.Systems.Init
{
    public class PathesInitSystem : DInitializer
    {
        private readonly ILevelContext _levelContext;
        private readonly IPathesFactory _pathesFactory;

        public PathesInitSystem()
        {
            _levelContext = DiContainer.Resolve<ILevelContext>();
            _pathesFactory = DiContainer.Resolve<IPathesFactory>();
        }

        protected override void OnInitialize()
        {
            _pathesFactory.CreatePathes<CarsPathesTag>(_levelContext.CarsPathSystem);
            _pathesFactory.CreatePathes<NpcsPathesTag>(_levelContext.NpcPathSystem);
        }
    }
}