using Scellecs.Morpeh;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.Game.InputServices;
using Sources.Infrastructure.Services;
using Sources.Utilities.Extensions;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update
{
    public class UserInputSystem : DUpdateSystem
    {
        private Filter _filter;
        private readonly IInputService _inputService;

        public UserInputSystem()
        {
            _inputService = DiContainer.Resolve<IInputService>();
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

            userCarInput.Vertical = _inputService.Vertical;
            userCarInput.Horizontal = _inputService.Horizontal;
        }
    }
}