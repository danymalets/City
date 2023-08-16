using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.App.Ui.Controllers;
using Sources.Services.UiServices.WindowBase.Screens;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.Ui.Screens.Input
{
    public class PlayerInputScreenController : ScreenController
    {
        private Entity _userEntity;
        private readonly PlayerInputScreen _playerInputScreen;
        
        public PlayerInputScreenController(PlayerInputScreen playerInputScreen) 
            : base(playerInputScreen, new ToogleAnimator(playerInputScreen))
        {
            _playerInputScreen = playerInputScreen;
        }

        private void OnEnterCarButtonClicked()
        {
            if (_userEntity.NotHas<PlayerInCar>() && _userEntity.TryGet(out CarInputPossibility carInputPossibility))
            {
                _userEntity.Set(new PlayerWantsEnterCarEvent
                {
                    CarPlaceData = new CarPlaceData(carInputPossibility.CarEntity, 0)
                });
            }
        }

        protected override void OnOpen()
        {
            DWorld world = DiContainer.Resolve<DWorld>();
            _userEntity = world.GetSingleton<UserTag>();
            
            _playerInputScreen.EnterCarButton.onClick.AddListener(OnEnterCarButtonClicked);

            _coroutineContext.RunEachFrame(Update, true);
        }

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                OnEnterCarButtonClicked();
            }

            _playerInputScreen.EnterCarButton.gameObject.SetActive(_userEntity.Has<CarInputPossibility>());
        }

        public Vector2 MoveInput => _playerInputScreen.Joystick.Direction;

        protected override void OnRefresh()
        {
        }

        protected override void OnClose()
        {
            _userEntity = null;
            _playerInputScreen.EnterCarButton.onClick.RemoveListener(OnEnterCarButtonClicked);
        }
    }
}