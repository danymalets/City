using Sources.Infrastructure.ApplicationInput;
using Sources.Infrastructure.Services;
using Sources.UI.Screens.Input;
using Sources.UI.System;
using UnityEngine;

namespace Sources.Game.InputServices
{
    public class InputService : IInputService
    {
        private readonly IApplicationInputService _applicationInput;
        private readonly InputScreen _inputScreen;

        public InputService()
        {
            _applicationInput = DiContainer.Resolve<IApplicationInputService>();
            _inputScreen = DiContainer.Resolve<IUiService>()
                .Get<InputScreen>();
        }

        public int Vertical =>
            _applicationInput.VerticalInput == 0 ? 
                _inputScreen.VerticalInput :
                _applicationInput.VerticalInput;

        public int Horizontal =>
            _applicationInput.HorizontalInput == 0 ?
                _inputScreen.HorizontalInput : 
                _applicationInput.HorizontalInput;
    }
}