using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Services;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class UserPlayerInputSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IPlayerInputService _playerInputService;

        public UserPlayerInputSystem()
        {
            _playerInputService = DiContainer.Resolve<IPlayerInputService>();
        }

        protected override void OnInitFilters()
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