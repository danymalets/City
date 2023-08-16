using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Ui.Controllers;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;

namespace Sources.App.Ui.Screens.Input
{
    public class CarInputScreenController : ScreenController
    {
        private Entity _userEntity;
        private readonly CarInputScreen _carInputScreen;

        public CarInputScreenController(CarInputScreen carInputScreen) 
            : base(carInputScreen, null)
        {
            _carInputScreen = carInputScreen;
        }

        protected override void OnOpen()
        {
            DWorld world = DiContainer.Resolve<DWorld>();
            _userEntity = world.GetSingleton<UserTag>();
            _coroutineContext.RunEachFrame(Update, true);
        }

        private void OnExitCarButtonClicked()
        {
            if (_userEntity.Has<PlayerFullyInCar>())
                _userEntity.Add<PlayerStartExitCarRequest>();
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.R))
            {
                OnExitCarButtonClicked();
            }

            _carInputScreen.ExitCarButton.interactable = _userEntity.Has<PlayerFullyInCar>();
        }

        public int VerticalInput => 
            GetInputValue(_carInputScreen.UpButton,
                _carInputScreen.DownButton);
        
        public int HorizontalInput =>
            GetInputValue(_carInputScreen.RightButton, 
                _carInputScreen.LeftButton);

        private int GetInputValue(GameplayButton positiveButton, GameplayButton negativeButton) =>
            positiveButton.PressValue - negativeButton.PressValue;

        protected override void OnRefresh()
        {
        }

        protected override void OnClose()
        {
            _userEntity = null;
        }
    }
}