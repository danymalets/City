using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Player;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Utils.MorpehUtils;
using Sources.Game.Ecs.Utils.MorpehUtils.Systems;
using Sources.Game.InputServices;
using Sources.Infrastructure.Services;
using Sources.Utilities.Extensions;

namespace Sources.Game.Ecs.Systems.Update.User
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