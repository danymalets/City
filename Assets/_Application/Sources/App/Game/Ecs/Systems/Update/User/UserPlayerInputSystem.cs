using Scellecs.Morpeh;
using Sources.App.Game.Ecs.Components.Player;
using Sources.App.Game.Ecs.Components.Tags;
using Sources.App.Game.Services;
using Sources.Services.Di;
using Sources.Utils.DMorpeh.MorpehUtils.Extensions;
using Sources.Utils.DMorpeh.MorpehUtils.Systems;
using Sources.Utils.Extensions;

namespace Sources.App.Game.Ecs.Systems.Update.User
{
    public class UserPlayerInputSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IPlayerInputService _playerInputService;

        public UserPlayerInputSystem()
        {
            _playerInputService = DiContainer.Resolve<IPlayerInputService>();
        }

        protected override void OnConstruct()
        {
            _filter = _world.Filter<UserTag>().Without<PlayerInCar>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_filter.NoOne())
                return;

            Entity userEntity = _filter.GetSingleton();

            ref UserPlayerInput userPlayerInput = ref userEntity.Get<UserPlayerInput>();

            userPlayerInput.MoveInput = _playerInputService.MoveInput;
        }
    }
}