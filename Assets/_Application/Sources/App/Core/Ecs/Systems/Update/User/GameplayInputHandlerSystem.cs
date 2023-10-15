using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Aspects.Player;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Player.InCar;
using Sources.App.Core.Ecs.Components.Player.User;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Services.Input;
using Sources.App.Data.Cars;
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
            _filter = _world.Filter<UserTag>().Build();
        }

        protected override void OnUpdate(float deltaTime)
        {
            GameplayInputData input = _gameplayInputAccessService.GameplayInputData;

            foreach (Entity userEntity in _filter)
            {
                ref UserCarInput userCarInput = ref userEntity.Get<UserCarInput>();

                ref UserPlayerInput userPlayerInput = ref userEntity.Get<UserPlayerInput>();

                userPlayerInput.MoveInput = input.PlayerMoveDirection;

                userCarInput.Vertical = input.CarMoveDirection.y;
                userCarInput.Horizontal = input.CarMoveDirection.x;

                if (input.WasCarEnterButtonPressed)
                {
                    if (userEntity.TryGet(out CarInputPossibility carInputPossibility))
                    {
                        userEntity.GetAspect<PlayerEnterCarAspect>().ForceEnterCar(
                            new CarPlaceData(carInputPossibility.CarEntity, 0));
                    }
                }

                if (input.WasCarExitButtonPressed)
                {
                    if (userEntity.Has<PlayerFullyInCar>())
                    {
                        userEntity.GetAspect<PlayerExitCarAspect>().FullyExitCar();
                    }
                }

                if (input.WasJumpPressed)
                {
                    userEntity.AddIfNotHas<JumpRequest>();
                }
            }
        }
    }
}