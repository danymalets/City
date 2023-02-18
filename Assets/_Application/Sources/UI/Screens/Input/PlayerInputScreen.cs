using System;
using Scellecs.Morpeh;
using Sources.Game.Ecs.Components.User;
using Sources.Game.Ecs.Utils.MorpehWrapper;
using Sources.UI.WindowBase.Screens;
using UnityEngine;
using UnityEngine.UI;
using Screen = Sources.UI.WindowBase.Screens.Screen;

namespace Sources.UI.Screens.Input
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