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
            _filter = _world.Filter<UserTag, MoveInput>();
        }

        protected override void OnUpdate(float deltaTime)
        {
            if (_filter.NoOne())
                return;

            Entity userEntity = _filter.GetSingleton();

            ref MoveInput moveInput = ref userEntity.Get<MoveInput>();

            moveInput.Vertical = _inputService.Vertical;
            moveInput.Horizontal = _inputService.Horizontal;
        }
    }
}