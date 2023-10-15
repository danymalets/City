using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Services.AssetsServices.IdleCarSpawns;
using Sources.App.Services.AssetsServices.IdleCarSpawns.Common;
using Sources.App.Services.AssetsServices.Monos.MonoEntities;
using Sources.App.Services.AssetsServices.Monos.MonoEntities.Props;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Init
{
    public class PropsInitSystem : DInitializer
    {
        private readonly ILevelContext _levelContext;
        private readonly IPropsFactory _propsFactory;

        public PropsInitSystem()
        {
            _levelContext = DiContainer.Resolve<ILevelContext>();
            _propsFactory = DiContainer.Resolve<IPropsFactory>();
        }

        protected override void OnInitialize()
        {
            foreach (IPropsMonoEntity propsMonoEntity in _levelContext.Props)
            {
                _propsFactory.Create(propsMonoEntity);
            }
        }
    }
}