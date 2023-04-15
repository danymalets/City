using Scellecs.Morpeh;
using Sources.App.Core.Ecs.Components.Player;
using Sources.CommonServices.UiServices.WindowBase.Screens;
using Sources.Utils.MorpehWrapper.MorpehUtils.Extensions;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.App.UI.Screens.Input
{
    public class PlayerInputScreen : Screen<Entity>
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
            _userEntity.Add<PlayerWantsEnterCar>();
        }
        
        

        private void Update()
        {
            if (UnityEngine.Input.GetKeyDown(KeyCode.E))
            {
                _userEntity.Add<PlayerWantsEnterCar>();
            }

            _enterCarButton.gameObject.SetActive(_userEntity.Has<CarInputPossibility>());
        }

        protected override void OnOpen(Entity userEntity)
        {
            _userEntity = userEntity;
        }

        protected override void OnClose()
        {
            _userEntity = null;
        }
    }
}