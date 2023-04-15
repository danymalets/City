using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Core.Ecs.Factories;
using _Application.Sources.App.Data.Common;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace _Application.Sources.App.Core.Ecs.Systems.Init
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