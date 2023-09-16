using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Core.Services;
using Sources.App.Core.Services.Input;
using Sources.Utils.CommonUtils.Extensions;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.MorpehWrapper.MorpehUtils.Systems;

namespace Sources.App.Core.Ecs.Systems.Update.User
{
    public class UserWithCarInputReceiverSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IGameplayInputAccessService _gameplayInputAccessService;

        public UserWithCarInputReceiverSystem()
        {
            _gameplayInputAccessService = DiContainer.Resolve<IGameplayInputAccessService>();
        }

        protected override void OnInitFilters()
        {
            _filter = _world.Filter<UserTag, PlayerInputInCarOn>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_filter.NoOne())
                return;

            Entity userEntity = _filter.GetSingleton();

            ref UserCarInput userCarInput = ref userEntity.Get<UserCarInput>();

            userCarInput.Vertical = _gameplayInputAccessService.GameplayInputData.CarMoveDirection.y;
            userCarInput.Horizontal = _gameplayInputAccessService.GameplayInputData.CarMoveDirection.x;
        }
    }
}