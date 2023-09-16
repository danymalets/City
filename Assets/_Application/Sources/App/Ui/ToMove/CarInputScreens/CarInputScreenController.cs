using System;
using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Ui.Controllers;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using Sources.Utils.Utils;
using UnityEngine;

namespace Sources.App.Ui.Screens.Input
{
    public class CarInputScreenController : ScreenController
    {
        private Entity _userEntity;
        private readonly CarInputScreen _carInputScreen;

        public event Action ExitCarButtonClicked;
        
        public CarInputScreenController(CarInputScreen carInputScreen) 
            : base(carInputScreen, new ToggleAnimator(carInputScreen))
        {
            _carInputScreen = carInputScreen;
        }

        protected override void OnOpen()
        {
            DWorld world = DiContainer.Resolve<DWorld>();
            _userEntity = world.GetSingleton<UserTag>();
            _coroutineContext.RunEachFrame(Update, true);
            
            _carInputScreen.ExitCarButton.onClick.AddListener(OnExitCarButtonClicked);
        }

        protected override void OnClose()
        {
            _carInputScreen.ExitCarButton.onClick.RemoveListener(OnExitCarButtonClicked);

            _userEntity = null;
        }

        private void OnExitCarButtonClicked()
        {
            ExitCarButtonClicked();

            // if (_userEntity.Has<PlayerFullyInCar>())
            //     _userEntity.Add<PlayerStartExitCarRequest>();
        }

        private void Update()
        {
            _carInputScreen.ExitCarButton.interactable = _userEntity.Has<PlayerFullyInCar>();
        }

        public Vector2 InputDirection => 
            new (UiUtils.GetInputValue(_carInputScreen.UpButton,
                _carInputScreen.DownButton),
                UiUtils.GetInputValue(_carInputScreen.RightButton, 
                _carInputScreen.LeftButton));

        protected override void OnRefresh()
        {
        }
    }
}