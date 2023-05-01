using Sources.App.Ui.Screens.Input;
using Sources.Services.ApplicationInputServices;
using Sources.Services.UiServices.System;
using Sources.Utils.Di;
using UnityEngine;

namespace Sources.App.Core.Services
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