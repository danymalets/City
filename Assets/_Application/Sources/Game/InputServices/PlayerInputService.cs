using Sources.Infrastructure.ApplicationInput;
using Sources.Infrastructure.Services;
using Sources.UI.Screens.Input;
using Sources.UI.System;

namespace Sources.Game.InputServices
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

        public float Vertical =>
            UseAppInput ? 
                _applicationInput.VerticalInput :
                _playerInputScreen.VerticalInput;

        public float Horizontal =>
            UseAppInput ?
                _applicationInput.HorizontalInput : 
                _playerInputScreen.HorizontalInput;

        private bool UseAppInput =>
            _applicationInput.HorizontalInput != 0 || _applicationInput.VerticalInput != 0;
    }
}