using _Application.Sources.App.Core.Ecs.Components.Player;
using _Application.Sources.App.Core.Ecs.Components.Tags;
using _Application.Sources.App.Core.Services;
using _Application.Sources.Utils.CommonUtils.Extensions;
using _Application.Sources.Utils.Di;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using _Application.Sources.Utils.MorpehWrapper.MorpehUtils.Systems;
using Scellecs.Morpeh;

namespace _Application.Sources.App.Core.Ecs.Systems.Update.User
{
    public class UserCarInputSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly ICarInputService _carInputService;

        public UserCarInputSystem()
        {
            _carInputService = DiContainer.Resolve<ICarInputService>();
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<UserTag, UserCarInput>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_filter.NoOne())
                return;

            Entity userEntity = _filter.GetSingleton();

            ref UserCarInput userCarInput = ref userEntity.Get<UserCarInput>();

            userCarInput.Vertical = _carInputService.Vertical;
            userCarInput.Horizontal = _carInputService.Horizontal;
        }
    }
}