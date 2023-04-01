using Sources.App.Game.UI.Screens.Input;
using Sources.App.Game.UI.System;
using Sources.App.Infrastructure.ApplicationInput;
using Sources.App.Infrastructure.Services;
using UnityEngine;

namespace Sources.App.Game.InputServices
{
    public class PlayerInputService : IPlayerInputService
    {
        private readonly IApplicationInputService _applicationInput;
        private readonly PlayerInputScreen _playerInputScreen;

        public PlayerInputService()
        {
            _applicationInput = DiContainer.Resolve<IApplicationInputService>();
            _playerInputScreen = DiContainer.Resolve<IUiService>()
                .Get<PlayerInputScreen>();
        }

        public Vector2 MoveInput => _playerInputScreen.MoveInput == Vector2.zero
            ? new Vector2(_applicationInput.HorizontalInput, _applicationInput.VerticalInput)
            : _playerInputScreen.MoveInput;
    }
}