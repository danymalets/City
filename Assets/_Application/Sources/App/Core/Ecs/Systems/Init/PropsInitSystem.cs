using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Ecs.Factories;
using Sources.App.Services.AssetsServices.Common.MonoEntities.Props;
using Sources.App.Services.AssetsServices.Common.Scene;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Init
{
    public class PropsInitSystem : CustomInitializer
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
            foreach (PropsMonoEntity propsMonoEntity in _levelContext.Props)
            {
                _propsFactory.Create(propsMonoEntity);
            }
        }
    }
}