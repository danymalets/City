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
    public class GameplayInputHandlerSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IGameplayInputAccessService _gameplayInputAccessService;

        public GameplayInputHandlerSystem()
        {
            _gameplayInputAccessService = DiContainer.Resolve<IGameplayInputAccessService>();
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<UserTag>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            foreach (Entity userEntity in _filter)
            {
                ref UserCarInput userCarInput = ref userEntity.Get<UserCarInput>();

                ref UserPlayerInput userPlayerInput = ref userEntity.Get<UserPlayerInput>();

                userPlayerInput.MoveInput = _gameplayInputAccessService.GameplayInputData.PlayerMoveDirection;

                userCarInput.Vertical = _gameplayInputAccessService.GameplayInputData.CarMoveDirection.y;
                userCarInput.Horizontal = _gameplayInputAccessService.GameplayInputData.CarMoveDirection.x;
            }
        }
    }
}