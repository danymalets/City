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
        private readonly CarInputScreen _carInputScreen;

        public InputService()
        {
            _applicationInput = DiContainer.Resolve<IApplicationInputService>();
            _carInputScreen = DiContainer.Resolve<IUiService>()
                .Get<CarInputScreen>();
        }

        public int Vertical =>
            _applicationInput.VerticalInput == 0 ? 
                _carInputScreen.VerticalInput :
                _applicationInput.VerticalInput;

        public int Horizontal =>
            _applicationInput.HorizontalInput == 0 ?
                _carInputScreen.HorizontalInput : 
                _applicationInput.HorizontalInput;
    }
}