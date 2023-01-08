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

        private void Awake()
        {
            _enterCarButton.onClick.AddListener(OnEnterCarButtonClicked);
        }

        private void OnEnterCarButtonClicked()
        {
            _userEntity.Add<UserWantsEnterCar>();
        }

        private void Update()
        {
            // Debug.Log($"joy {_joystick.Direction}");
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