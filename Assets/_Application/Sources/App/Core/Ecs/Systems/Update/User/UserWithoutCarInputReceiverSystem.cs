using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.User;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Services;
using Sources.App.Core.Services.Input;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class UserWithoutCarInputReceiverSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IGameplayInputAccessService _playerInputService;

        public UserWithoutCarInputReceiverSystem()
        {
            _playerInputService = DiContainer.Resolve<IGameplayInputAccessService>();
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

            userPlayerInput.MoveInput = _playerInputService.GameplayInputData.PlayerMoveDirection;
        }
    }
}