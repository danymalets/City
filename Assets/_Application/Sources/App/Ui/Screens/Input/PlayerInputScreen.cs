using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.App.Core.Ecs.Components.Tags;
using Sources.App.Data.Cars;
using Sources.Utils.Di;
using Sources.Utils.MorpehWrapper.MorpehUtils;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;
using UnityEngine.UI;
using Screen = Sources.Services.UiServices.WindowBase.Screens.Screen;

namespace Sources.App.Ui.Screens.Input
{
    public class PlayerInputScreen : Sources.Services.UiServices.WindowBase.Screens.Screen
    {
        [SerializeField]
        private Joystick _joystick;

        [SerializeField]
        private Button _enterCarButton;

        private Entity _userEntity;
        public Vector2 MoveInput => _joystick.Direction;

        private void Awake()
        {
            _enterCarButton.onClick.AddListener(OnEnterCarButtonClicked);
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

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                OnEnterCarButtonClicked();
            }

            _enterCarButton.gameObject.SetActive(_userEntity.Has<CarInputPossibility>());
        }

        protected override void OnOpen()
        {
            DWorld world = DiContainer.Resolve<DWorld>();
            _userEntity = world.GetSingleton<UserTag>();
        }

        protected override void OnClose()
        {
            _userEntity = null;
        }
    }
}