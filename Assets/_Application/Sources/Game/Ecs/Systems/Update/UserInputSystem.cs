using Leopotam.Ecs;
using Sources.Game.Ecs.Components;
using Sources.Game.Ecs.Components.Tags;
using Sources.Game.InputServices;
using Sources.Infrastructure.Services;
using UnityEngine;

namespace Sources.Game.Ecs.Systems.Update
{
    public class UserInputSystem : IEcsRunSystem
    {
        private EcsFilter<UserTag, MoveInput> _filter;
        private readonly IInputService _inputService;

        public UserInputSystem()
        {
            _inputService = DiContainer.Resolve<IInputService>();
        }

        public void Run()
        {
            foreach (int i in _filter)
            {
                ref MoveInput moveInput = ref _filter.Get2(i);

                moveInput.Vertical = _inputService.Vertical;
                moveInput.Horizontal = _inputService.Horizontal;
            }
        }
    }
}