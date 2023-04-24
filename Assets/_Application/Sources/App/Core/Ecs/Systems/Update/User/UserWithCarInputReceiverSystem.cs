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
    public class UserWithCarInputReceiverSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly ICarInputService _carInputService;

        public UserWithCarInputReceiverSystem()
        {
            _carInputService = DiContainer.Resolve<ICarInputService>();
        }

        protected override void OnInitFilters()
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