using Sources.App.Game.UI.Screens.Input;
using Sources.Services.ApplicationInput;
using Sources.Services.Di;
using Sources.Services.Ui.System;

namespace Sources.App.Game.Services
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