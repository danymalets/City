using System;
using Sources.App.Ui.Controllers;
using Sources.App.Ui.Controllers.Animators;
using UnityEngine;

namespace Sources.App.Ui.ToMove.PlayerInputScreens
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