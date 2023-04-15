using _Application.Sources.App.UI.Screens.Input;
using _Application.Sources.CommonServices.ApplicationInputServices;
using _Application.Sources.CommonServices.UiServices.System;
using _Application.Sources.Utils.Di;
using UnityEngine;

namespace _Application.Sources.App.Core.Services
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