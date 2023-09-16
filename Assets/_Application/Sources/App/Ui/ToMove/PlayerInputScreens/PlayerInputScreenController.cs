using System;
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
    public class PlayerInputScreenController : ScreenController
    {
        private readonly PlayerInputScreen _playerInputScreen;

        public event Action EnterCarButtonClicked; 
        
        public PlayerInputScreenController(PlayerInputScreen playerInputScreen) 
            : base(playerInputScreen, new ToggleAnimator(playerInputScreen))
        {
            _playerInputScreen = playerInputScreen;
        }

        protected override void OnOpen()
        {
            _playerInputScreen.EnterCarButton.onClick.AddListener(OnEnterCarButtonClicked);
            
        }

        private void OnEnterCarButtonClicked()
        {
            EnterCarButtonClicked?.Invoke();
        }

        // private void Update()
        // {
        //     if (UnityEngine.Input.GetKeyDown(KeyCode.E))
        //     {
        //         OnEnterCarButtonClicked();
        //     }
        //
        //     _playerInputScreen.EnterCarButton.gameObject.SetActive(_userEntity.Has<CarInputPossibility>());
        // }

        public Vector2 InputDirection => _playerInputScreen.Joystick.Direction;

        protected override void OnRefresh()
        {
        }

        protected override void OnClose()
        {
            _playerInputScreen.EnterCarButton.onClick.RemoveListener(OnEnterCarButtonClicked);
        }
    }
}