using Sources.App.Game.UI.Screens.Input;
using Sources.App.Game.UI.System;
using Sources.App.Infrastructure.ApplicationInput;
using Sources.Di;

namespace Sources.App.Game.InputServices
{
    public class CarInputService : ICarInputService
    {
        private readonly IApplicationInputService _applicationInput;
        private readonly CarInputScreen _carInputScreen;

        public CarInputService()
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