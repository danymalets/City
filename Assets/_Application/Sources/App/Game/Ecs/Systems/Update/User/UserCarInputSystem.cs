using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Ecs.Components.User;
using Sources.App.Game.InputServices;
using Sources.Di;
using Sources.DMorpeh.MorpehUtils.Extensions;
using Sources.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Extensions;

namespace Sources.App.Game.Ecs.Systems.Update.User
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