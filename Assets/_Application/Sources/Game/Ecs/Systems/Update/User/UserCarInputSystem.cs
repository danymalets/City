using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Game.InputServices;
using Sources.Infrastructure.Services;
using Sources.Utilities.Extensions;

namespace Sources.Game.Ecs.Systems.Update.User
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